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
            try
            {
                //Get Data From Database - Domain models
                var rentals = await _rentalRepository.GetAllAsync();

                //Map Domain Models to DTOs
                return Ok(_mapper.Map<List<CarRentalRecordDto>>(rentals));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Get Single Rental

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            try
            {
                //Get Car From Database: Domain Model
                var rental = await _rentalRepository.GetByIdAsync(id);

                if (rental == null)
                {
                    return NotFound();
                }

                //Map/Convert Domain Model to DTO
                //Return DTO back to client
                return Ok(_mapper.Map<CarRentalRecordDto>(rental));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Add Rental

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRentalReqDto addRentalReq)
        {

            try
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
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Update Rental

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRentalRecord updateRental)
        {
            try
            {
                //Map DTO to Domain Model
                var rentalToBeUpdated = _mapper.Map<CarRentalRecord>(updateRental);
                //Update if region exists
                rentalToBeUpdated = await _rentalRepository.UpdateAsync(id, rentalToBeUpdated);

                if (rentalToBeUpdated == null)
                {
                    return NotFound();
                }

                // Convert Domain Model to DTO

                return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeUpdated));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Delete A Rental
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var rentalToBeDeleted = await _rentalRepository.DeleteAsync(id);

                if (rentalToBeDeleted == null)
                {
                    return NotFound();
                }

                // returning deleted rental == Optional { return Ok() also f9}

                // Convert Domain Model to DTO

                return Ok(_mapper.Map<CarRentalRecordDto>(rentalToBeDeleted));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


    }
}
