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
            await _carRentalDb.SaveChangesAsync();
            return record;
        }

        public async Task<CarRentalRecord?> DeleteAsync(int id)
        {
            var existingRecord = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord != null)
            {
                return null;
            }

            _carRentalDb.CarRentalRecords.Remove(existingRecord);
            _carRentalDb.SaveChangesAsync();
            return existingRecord;
        }

        public async  Task<List<CarRentalRecord>> GetAllAsync()
        {
            return await _carRentalDb.CarRentalRecords.ToListAsync();
        }

        public async Task<CarRentalRecord?> GetByIdAsync(int id)
        {
            return await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);    
        }

        public async Task<CarRentalRecord?> UpdateAsync(int id, CarRentalRecord record)
        {
            var existingRecord = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord != null)
            {
                return null;
            }

            existingRecord.CustomerName = record.CustomerName;
            existingRecord.DrivingLicenceNo = record.DrivingLicenceNo;
            existingRecord.PickUpDate = record.PickUpDate;
            existingRecord.DropDate = record.DropDate;
            existingRecord.Cost = record.Cost;
            existingRecord.CompletionStatus = record.CompletionStatus;
            existingRecord.VehicleId = record.VehicleId;

            _carRentalDb.SaveChangesAsync();
            return existingRecord;

        }
    }
}
