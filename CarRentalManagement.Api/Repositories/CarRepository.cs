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

        public async Task<Car> CreateAsync(int makeId, int modelId, Car car)
        {
            string sqlQuery = "exec sp_AddCar @LicensePlateNumber,@Color,@Availability," +
                "@MakeId,@ModelId,@NewCarId OUTPUT,@ResultType OUTPUT";

            var parameters = new[]
            {
                new SqlParameter("@MakeId", makeId),
                new SqlParameter("@ModelId", modelId),
                new SqlParameter("@Color", car.Color),
                new SqlParameter("@LicensePlateNumber",car.LicensePlateNumber),
                new SqlParameter("@Availability",car.Availability),
                new SqlParameter("@NewCarId",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@ResultType",SqlDbType.NVarChar,50){Direction=ParameterDirection.Output}
            };

            await _carRentalDb.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

            var resultType = (string)parameters[6].Value;
            if (resultType == "LPN_Error")
                throw new BadRequestException($"Car With License Plate No. : {car.LicensePlateNumber} Already Exist");
            else if (resultType == "MkId_Error")
                throw new NotFoundException($"Make Id : {makeId} doesn't exist");
            else if (resultType == "MdlId_Error")
                throw new NotFoundException($"Model Id : {modelId} doesn't exist");
            else if (resultType == "Color_Error")
                throw new BadRequestException("Model Limit exceeded : For a model, maximum 3 car of same color is allowed");

            var newCarId = (int)parameters[5].Value;
            var addedCar = await GetByIdAsync(newCarId);

            return addedCar;
        }

        public async Task<Car?> DeleteAsync(int id)
        {
            string sqlQuery = "exec usp_deleteCar @Id, @Result OUTPUT";

            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Result",SqlDbType.NVarChar,50){Direction=ParameterDirection.Output}

            };

            var carToBeDeleted = await GetByIdAsync(id);

            await _carRentalDb.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

            var result = (string)parameters[1].Value;

            if (result == "Not Found")
                throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");

            else if (result == "Availability = False")
                throw new BadRequestException("Car Availability Should Be True, To Delete A Car");

            if (result == "Success")
            {    
                return carToBeDeleted;
            }
            return null;
        }

        public async  Task<List<Car>> GetAllAsync()
        {
            //var cars = await _carRentalDb.Cars.ToListAsync();
            string sqlQuery = "exec usp_getAllCars";
            var cars = await _carRentalDb.Cars.FromSqlRaw(sqlQuery).ToListAsync();
            if (cars.Count == 0)
                return new List<Car>();
            return cars;
        }

        public async Task<Car?> GetByIdAsync(int id)
        {
            //var car = await _carRentalDb.Cars.FirstOrDefaultAsync(x => x.Id == id);
            string sqlQuery = "SELECT * FROM Cars WHERE Id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", id);
            var car = await _carRentalDb.Cars.FromSqlRaw(sqlQuery, parameter).FirstOrDefaultAsync();
            if (car == null)
                throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");
            return car;
        }

        public async Task<Car?> UpdateAsync(int id, Car car)
        {
            // Parameters should pass in same order as it is present in Db stored procedure
            string sqlQuery = "exec usp_updateCar @Id," +
                "@Color,@LicensePlateNumber,@ResultType OUTPUT";

            var parameters = new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Color", car.Color),
                new SqlParameter("@LicensePlateNumber", car.LicensePlateNumber),
                new SqlParameter("@ResultType",SqlDbType.NVarChar,50){Direction=ParameterDirection.Output}
            };

            await _carRentalDb.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

            var resultType = (string)parameters[3].Value;

            if (resultType == "Not Found")
                throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");

            else if (resultType == "LPN_Error")
                throw new BadRequestException($"Car With License Plate No. : {car.LicensePlateNumber} Already Exist");

            else if (resultType == "Color_Error")
                throw new BadRequestException("Model Limit exceeded : For a model, maximum 3 car of same color is allowed");

            if (resultType == "Success")
            {
                var updatedCar = await GetByIdAsync(id);
                return updatedCar;
            }
                
            return null;
        }
 
    }
}
