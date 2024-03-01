using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Exceptions;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarRentalManagement.Api.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalDbContext _carRentalDb;

        public CarRepository(CarRentalDbContext carRentalDb) 
        {
            _carRentalDb = carRentalDb;
        }

        public async Task<int> CreateAsync(int makeId, int modelId, Car car)
        {
            string sqlQuery = "exec sp_AddCar @LicensePlateNumber,@Color,@Availability,@MakeId,@ModelId,@NewCarId OUTPUT";

            var parameters = new[]
            {
                new SqlParameter("@MakeId", makeId),
                new SqlParameter("@ModelId", modelId),
                new SqlParameter("@Color", car.Color),
                new SqlParameter("@LicensePlateNumber",car.LicensePlateNumber),
                new SqlParameter("@Availability",car.Availability),
                new SqlParameter("@NewCarId",SqlDbType.Int){Direction=ParameterDirection.Output}
            };

            await _carRentalDb.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

            var newCarId = (int)parameters[5].Value;
            return newCarId;
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
                throw new BadRequestException("Car Availability Should Be True, To Delete A Car");
            
        }

        public async  Task<List<Car>> GetAllAsync()
        {
            var cars = await _carRentalDb.Cars.ToListAsync();
            if (cars.Count == 0)
                return new List<Car>();
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

            existingCar.LicensePlateNumber = car.LicensePlateNumber;
            existingCar.Color = car.Color;
            existingCar.Availability = car.Availability;

            var carsWithSameColor = _carRentalDb.Cars.Where(c => c.Model == existingCar.Model && c.Color == existingCar.Color).ToList();
            if (carsWithSameColor.Count > 3)
                throw new BadRequestException("Model Limit exceeded : For a model, maximum 3 car of same color is allowed");

            var carWithSameNo = _carRentalDb.Cars.SingleOrDefault(c => c.LicensePlateNumber == car.LicensePlateNumber);
            if (carWithSameNo != null)
                throw new BadRequestException($"Car With License Plate No. : {car.LicensePlateNumber} Already Exist");

            await _carRentalDb.SaveChangesAsync();
            return existingCar;
        }
 
    }
}
