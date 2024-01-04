using CarRentalManagement.Api.Data;
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
            if (existingCar != null)
            {
                return null;
            }
            _carRentalDb.Cars.Remove(existingCar);
            _carRentalDb.SaveChanges();
            return existingCar;
        }

        public async  Task<List<Car>> GetAllAsync()
        {
            return await _carRentalDb.Cars.ToListAsync();
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            return await _carRentalDb.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car?> UpdateAsync(int id, Car car)
        {
            var existingCar = await _carRentalDb.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCar != null)
            {
                return null;
            }

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
