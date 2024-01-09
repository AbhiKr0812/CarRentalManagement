using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Api.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly CarRentalDbContext _carRentalDb;

        public RentalRepository(CarRentalDbContext carRentalDb)
        {
            _carRentalDb = carRentalDb;
        }

        public async Task<CarRentalRecord> CreateAsync(CarRentalRecord record)
        {
            await _carRentalDb.CarRentalRecords.AddAsync(record);
            
            // Shuffle Car Availability
            var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id == record.VehicleId);
            car.Availability = false;

            await _carRentalDb.SaveChangesAsync();
            return record;
        }

        public async Task<CarRentalRecord?> DeleteAsync(int id)
        {
            var existingRecord = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord == null)
                throw new Exception("There Is No Such Record Present")


            if (existingRecord.CompletionStatus)
            {
                _carRentalDb.CarRentalRecords.Remove(existingRecord);
                _carRentalDb.SaveChangesAsync();
                return existingRecord;
            }
            else
                throw new Exception("Without completion approval of the rental, record can't be deleted.");

            
        }

        public async  Task<List<CarRentalRecord>> GetAllAsync()
        {
            var rentals = await _carRentalDb.CarRentalRecords.ToListAsync();
            if (rentals.Count == 0)
                throw new Exception("There is no record available at the moment");
            return rentals;
        }

        public async Task<CarRentalRecord?> GetByIdAsync(int id)
        {
            var rental = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (rental == null) throw new Exception("There is no such record exist");
            return rental;
        }

        public async Task<CarRentalRecord?> UpdateAsync(int id, CarRentalRecord record)
        {
            var existingRecord = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord == null) throw new Exception("There is no such record exist");

            existingRecord.CustomerName = record.CustomerName;
            existingRecord.DrivingLicenceNo = record.DrivingLicenceNo;
            existingRecord.PickUpDate = record.PickUpDate;
            existingRecord.DropDate = record.DropDate;
            existingRecord.Cost = record.Cost;
            existingRecord.CompletionStatus = record.CompletionStatus;
            existingRecord.VehicleId = record.VehicleId;

            // Shuffle Car Availability
            var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id == record.VehicleId);
            car.Availability = record.CompletionStatus;

            _carRentalDb.SaveChangesAsync();
            return existingRecord;

        }

        //private async void ShuffleCarAvailability(int id)
        //{
        //    var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id == id);
        //    if (car.Availability)
        //        car.Availability = false;
        //    car.Availability = true;

        //    _carRentalDb.SaveChangesAsync();
        //}
    }
}
