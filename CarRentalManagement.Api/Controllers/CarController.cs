using AutoMapper;
using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRentalDbContext _carRentalDb;
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(CarRentalDbContext carRentalDb,
            ICarRepository carRepository, IMapper mapper)
        {
            _carRentalDb = carRentalDb;
            _carRepository = carRepository;
            _mapper = mapper;
        }


        #region Get All Cars
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //Get Data From Database - Domain models
                var cars = await _carRepository.GetAllAsync();

                //Map Domain Models to DTOs
                return Ok(_mapper.Map<List<CarDto>>(cars));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Get Single Car 
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            //Get Car From Database: Domain Model
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            //Map/Convert Domain Model to DTO
            //Return DTO back to client
            return Ok(_mapper.Map<CarDto>(car));
        }

        #endregion

        #region Add New Car
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCarRequestDto carRequestDto)
        {

            //Map or Convert DTO to Domain Model
            var newCar = _mapper.Map<Car>(carRequestDto);

            //Use Domain Model to create Region
            newCar = await _carRepository.CreateAsync(newCar);
            await _carRentalDb.SaveChangesAsync();

            //Map Domain Model back to DTO
            var carDto = _mapper.Map<CarDto>(newCar);

            return CreatedAtAction(nameof(GetById), new { newCar.Id }, carDto);

        }
        #endregion

        #region Update A Car
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarReqDto updateCar)
        {
            //Map DTO to Domain Model
            var carToBeUpdated = _mapper.Map<Car>(updateCar);
            //Update if region exists
            carToBeUpdated = await _carRepository.UpdateAsync(id, carToBeUpdated);

            if (carToBeUpdated == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO

            return Ok(_mapper.Map<CarDto>(carToBeUpdated));
        }

        #endregion

        #region Delete A Car
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var carToBeDeleted = await _carRepository.DeleteAsync(id);

            if (carToBeDeleted == null)
            {
                return NotFound();
            }

            // returning deleted car == Optional { return Ok() also f9}

            // Convert Domain Model to DTO

            return Ok(_mapper.Map<CarDto>(carToBeDeleted));
        }

        #endregion
    }
}
