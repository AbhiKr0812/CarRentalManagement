using AutoMapper;
using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;
using CarRentalManagement.Api.Repositories;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly CarRentalDbContext _carRentalDb;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public RentalsController(CarRentalDbContext carRentalDb,
            IRentalRepository rentalRepository,IMapper mapper)
        {
            _carRentalDb = carRentalDb;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        #region Get All Rentals

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain models
            var rentals = await _rentalRepository.GetAllAsync();

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRentalReqDto addRentalReq)
        {

            //Map or Convert DTO to Domain Model
            var newRental = _mapper.Map<CarRentalRecord>(addRentalReq);

            //Use Domain Model to create Region
            newRental = await _rentalRepository.CreateAsync(newRental);
            await _carRentalDb.SaveChangesAsync();

            //Map Domain Model back to DTO
            var rentalDto = _mapper.Map<CarRentalRecordDto>(newRental);

            return CreatedAtAction(nameof(GetById), new { newRental.Id }, rentalDto);

        }

        #endregion

        #region Update Rental

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRentalRecord updateRental)
        {
            //Map DTO to Domain Model
            var rentalToBeUpdated = _mapper.Map<CarRentalRecord>(updateRental);
            //Update if region exists
            rentalToBeUpdated = await _rentalRepository.UpdateAsync(id, rentalToBeUpdated);

            // Convert Domain Model to DTO

            return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeUpdated));
        }

        #endregion

        #region Delete A Rental
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var rentalToBeDeleted = await _rentalRepository.DeleteAsync(id);

            // returning deleted rental == Optional { return Ok() also f9}
            // Convert Domain Model to DTO
            return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeDeleted));
        }

        #endregion


    }
}
