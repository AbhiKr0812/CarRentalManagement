using AutoMapper;
using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRentalDbContext _carRentalDb;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CarsController> _logger;

        public CarsController(CarRentalDbContext carRentalDb,
            ICarRepository carRepository, IMapper mapper, ILogger<CarsController> logger)
        {
            _carRentalDb = carRentalDb;
            _carRepository = carRepository;
            _mapper = mapper;
            _logger = logger;
        }


        #region Get All Cars
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain models
            var cars = await _carRepository.GetAllAsync();

            //Map Domain Models to DTOs
            _logger.LogInformation($" Existing Cars : {JsonSerializer.Serialize(cars)} Displayed Successfully");
            return Ok(_mapper.Map<List<CarDto>>(cars));
        }

        #endregion

        #region Get Single Car 
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            //Get Car From Database: Domain Model
            var car = await _carRepository.GetByIdAsync(id);

            //Map/Convert Domain Model to DTO
            //Return DTO back to client
            _logger.LogInformation($" Serched Car : {JsonSerializer.Serialize(car)} Displayed Successfully");
            return Ok(_mapper.Map<CarDto>(car));
        }

        #endregion

        #region Add New Car
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] AddCarRequestDto carRequestDto)
        {
            //Map or Convert DTO to Domain Model
            var newCar = _mapper.Map<Car>(carRequestDto);

            //Use Domain Model to create Region
            newCar = await _carRepository.CreateAsync(newCar);
            await _carRentalDb.SaveChangesAsync();

            //Map Domain Model back to DTO
            var carDto = _mapper.Map<CarDto>(newCar);

            _logger.LogInformation($" Car : {JsonSerializer.Serialize(carDto)} Got Added Successfully");
            return CreatedAtAction(nameof(GetById), new { newCar.Id }, carDto);
        }
        #endregion

        #region Update A Car
        [HttpPut("Update/{id:int}")]
        //[Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarReqDto updateCar)
        {

            // Map DTO to Domain Model
            var carToBeUpdated = _mapper.Map<Car>(updateCar);
            // Update if region exists
            carToBeUpdated = await _carRepository.UpdateAsync(id, carToBeUpdated);

            // Convert Domain Model to DTO

            _logger.LogInformation($" Car : {JsonSerializer.Serialize(carToBeUpdated)} Got Updated Successfully");
            return Ok(_mapper.Map<CarDto>(carToBeUpdated));
        }

        #endregion

        #region Toggle Car Availability
        [HttpPut("Availability/{id:int}")]
        //[Route("{id:int}")]
        public async Task<IActionResult> ShuffleAvailability([FromRoute] int id)
        {

            // Update if region exists
            var updatedCar = await _carRepository.ShuffleCarAvailabilityAsync(id);

            // Convert Domain Model to DTO
            return Ok(_mapper.Map<CarDto>(updatedCar));
        }

        #endregion

        #region Delete A Car
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var carToBeDeleted = await _carRepository.DeleteAsync(id);

            // returning deleted car == Optional { return Ok() also f9}

            // Convert Domain Model to DTO

            _logger.LogInformation($" Car : {JsonSerializer.Serialize(carToBeDeleted)} Deleted Successfully");
            return Ok(_mapper.Map<CarDto>(carToBeDeleted));
        }

        #endregion
    }
}
