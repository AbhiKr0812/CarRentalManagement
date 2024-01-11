using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Exceptions;
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
            var errorMsg = ValidateRental(record);
            if (errorMsg.Length == 0)
            {
                await _carRentalDb.CarRentalRecords.AddAsync(record);

                // Shuffle Car Availability
                var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id == record.VehicleId);
                car.Availability = false;

                await _carRentalDb.SaveChangesAsync();
                return record;
            }
            throw new BadRequestException(errorMsg);
            
        }

        public async Task<CarRentalRecord?> DeleteAsync(int id)
        {
            var existingRecord = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord == null)
                throw new NotFoundException($"There Is No Such Record Present With The Id: {id}");


            if (existingRecord.CompletionStatus)
            {
                _carRentalDb.CarRentalRecords.Remove(existingRecord);
                _carRentalDb.SaveChangesAsync();
                return existingRecord;
            }
            else
                throw new BadRequestException("A Rental Record Completion-Approval Should Be True, Before Deletion");

            
        }

        public async  Task<List<CarRentalRecord>> GetAllAsync()
        {
            var rentals = await _carRentalDb.CarRentalRecords.ToListAsync();
            if (rentals.Count == 0)
                throw new NotFoundException("There is no record available at this moment");
            return rentals;
        }

        public async Task<CarRentalRecord?> GetByIdAsync(int id)
        {
            var rental = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (rental == null) throw new NotFoundException($"There Is No Such Record Present With The Id: {id}");
            return rental;
        }

        public async Task<CarRentalRecord?> UpdateAsync(int id, CarRentalRecord record)
        {
            var existingRecord = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord == null) throw new NotFoundException($"There Is No Such Record Present With The Id: {id}");

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
  
        private  string ValidateRental(CarRentalRecord carRental)
        {
            var errorMessage = "";

            var rental = _carRentalDb.CarRentalRecords.
                FirstOrDefault(r => r.DrivingLicenceNo == carRental.DrivingLicenceNo && r.DropDate >= DateTime.Now);
            if (rental != null)
                return errorMessage = ($"{carRental.DrivingLicenceNo} is already occupied with active rental.");
            
            if (carRental.PickUpDate == carRental.DropDate || carRental.PickUpDate > carRental.DropDate)
                return errorMessage = "Drop Date/Time Should Be Greater Than PickUp Date/Time.";
            else if (carRental.DropDate - carRental.PickUpDate < TimeSpan.FromHours(8))
                return errorMessage = " At least car should be rented for minimum duration of 8 hours.";

            return errorMessage;
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
