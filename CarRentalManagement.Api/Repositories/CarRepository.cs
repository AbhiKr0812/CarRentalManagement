using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Exceptions;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Api.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _carRentalDb;

        public CarRepository(CarRentalDbContext carRentalDb) 
        {
            _carRentalDb = carRentalDb;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            await _carRentalDb.Cars.AddAsync(car);
            await _carRentalDb.SaveChangesAsync();
            return car;
        }

        public async Task<Car?> DeleteAsync(int id)
        {
            var existingCar =  await _carRentalDb.Cars.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingCar == null)
                throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");

            if (existingCar.Availability == true)
            {
                _carRentalDb.Cars.Remove(existingCar);
                _carRentalDb.SaveChanges();
                return existingCar;
            }
            else
                throw new BadRequestException("Car Availability Should Be True, Before Deleting");
            
        }

        public async  Task<List<Car>> GetAllAsync()
        {
            var cars = await _carRentalDb.Cars.ToListAsync();
            if (cars.Count == 0)
                throw new NotFoundException("There Is No Car Available At This Moment");
            return cars;
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            var car = await _carRentalDb.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
                throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");
            return car;
        }

        public async Task<Car?> UpdateAsync(int id, Car car)
        {
            var existingCar = await _carRentalDb.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCar == null)
                throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");

            existingCar.Name = car.Name;
            existingCar.LicensePlateNumber = car.LicensePlateNumber;
            existingCar.Make = car.Make;
            existingCar.Color = car.Color;
            existingCar.Availability = car.Availability;

            _carRentalDb.SaveChangesAsync();
            return existingCar;
        }
    }
}
