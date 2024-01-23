using AutoMapper;
using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;
using CarRentalManagement.Api.Repositories;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly CarRentalDbContext _carRentalDb;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RentalsController> _logger;

        public RentalsController(CarRentalDbContext carRentalDb,
            IRentalRepository rentalRepository,IMapper mapper, ILogger<RentalsController> logger)
        {
            _carRentalDb = carRentalDb;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
            _logger = logger;
        }

        #region Get Open Rentals

        [HttpGet("Open")]
        public async Task<IActionResult> GetOpenRentals()
        {
            //Get Data From Database - Domain models
            var rentals = await _rentalRepository.GetOpenRentalsAsync();

            //Map Domain Models to DTOs
            return Ok(_mapper.Map<List<CarRentalRecordDto>>(rentals));

        }

        #endregion

        #region Get Closed Rentals
        [HttpGet("Closed")]
        public async Task<IActionResult> GetClosedRentals()
        {
            //Get Data From Database - Domain models
            var rentals = await _rentalRepository.GetClosedRentalsAsync();

            //Map Domain Models to DTOs
            return Ok(_mapper.Map<List<CarRentalRecordDto>>(rentals));
        }

        #endregion

        #region Get Single Rental

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //Get Car From Database: Domain Model
            var rental = await _rentalRepository.GetByIdAsync(id);

            //Map/Convert Domain Model to DTO
            //Return DTO back to client
            return Ok(_mapper.Map<CarRentalRecordDto>(rental));
        }

        #endregion

        #region Add Rental

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] AddRentalReqDto addRentalReq)
        {

            //Map or Convert DTO to Domain Model
            var newRental = _mapper.Map<CarRentalRecord>(addRentalReq);

            //Use Domain Model to create Region
            newRental = await _rentalRepository.CreateAsync(newRental);
            await _carRentalDb.SaveChangesAsync();

            //Map Domain Model back to DTO
            var rentalDto = _mapper.Map<CarRentalRecordDto>(newRental);

            _logger.LogInformation($" New Rental : {JsonSerializer.Serialize(rentalDto)} Got Added Successfully");
            return CreatedAtAction(nameof(GetById), new { newRental.Id }, rentalDto);

        }

        #endregion

        #region Update Rental

        [HttpPut("Update/{id:int}")]
        //[Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRentalRecord updateRental)
        {
            //Map DTO to Domain Model
            var rentalToBeUpdated = _mapper.Map<CarRentalRecord>(updateRental);
            //Update if region exists
            rentalToBeUpdated = await _rentalRepository.UpdateAsync(id, rentalToBeUpdated);

            // Convert Domain Model to DTO
            _logger.LogInformation($"Existing Rental : {JsonSerializer.Serialize(rentalToBeUpdated)} Got Updated Successfully");
            return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeUpdated));
        }

        #endregion

        #region Approve Rental Completion

        //[HttpPut("Approve/{id:int}")]
        ////[Route("{id:int}")]
        //public async Task<IActionResult> Update([FromRoute] int id)
        //{
        //    //Update if region exists
        //    var rentalToBeApprove = await _rentalRepository.ApproveCompletion(id);

        //    // Convert Domain Model to DTO

        //    return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeApprove));
        //}

        #endregion

        #region Delete A Rental
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var rentalToBeDeleted = await _rentalRepository.DeleteAsync(id);

            // returning deleted rental == Optional { return Ok() also f9}
            // Convert Domain Model to DTO
            _logger.LogInformation($"Existing Rental : {JsonSerializer.Serialize(rentalToBeDeleted)} Got Deleted Successfully");
            return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeDeleted));
        }

        #endregion


    }
}
