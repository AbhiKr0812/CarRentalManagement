﻿using CarRentalManagement.Api.Data;
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
                if(record.CompletionStatus == false)
                {
                    await _carRentalDb.CarRentalRecords.AddAsync(record);

                    // Shuffle Car Availability
                    var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id == record.VehicleId);
                    car.Availability = false;

                    await _carRentalDb.SaveChangesAsync();
                    return record;
                }
                throw new BadRequestException("Completion Status Should Be False, While Adding");
            }
            throw new BadRequestException(errorMsg);
            
        }

        public async Task<List<CarRentalRecord>> GetOpenRentalsAsync()
        {
            var rentals = await _carRentalDb.CarRentalRecords.Where(r => r.CompletionStatus == false).ToListAsync();
            if (rentals.Count == 0)
                throw new NotFoundException("There is no record available at this moment");
            foreach (var rental in rentals)
            {
                var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id .Equals(rental.VehicleId));
                rental.CarName = car.Name + " " + car.Color;
            }
            return rentals;
        }

        public async Task<List<CarRentalRecord>> GetClosedRentalsAsync()
        {
            var rentals = await _carRentalDb.CarRentalRecords.Where(r => r.CompletionStatus == true).ToListAsync();
            if (rentals.Count == 0)
                throw new NotFoundException("There is no record available at this moment");
            foreach (var rental in rentals)
            {
                var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id.Equals(rental.VehicleId));
                rental.CarName = car.Name + " " + car.Color;
            }
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

        public async Task<CarRentalRecord?> ApproveCompletion(int id)
        {
            var carRental = await _carRentalDb.CarRentalRecords.FirstOrDefaultAsync(c => c.Id == id);
            if (carRental != null)
            {
                if (carRental.CompletionStatus == true)
                    carRental.CompletionStatus = false;
                else if (carRental.CompletionStatus == false)
                    carRental.CompletionStatus = true;

                _carRentalDb.SaveChangesAsync();
                return carRental;
            }
            throw new NotFoundException($"Car With The Provided Id : {id} Doesn't Exist");
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
                throw new BadRequestException("Rental Record Completion-Status Should Be True, Before Deletion");


        }

        private  string ValidateRental(CarRentalRecord carRental)
        {
            var errorMessage = "";

            var rental = _carRentalDb.CarRentalRecords.
                FirstOrDefault(r => r.DrivingLicenceNo == carRental.DrivingLicenceNo && r.DropDate >= DateTime.UtcNow);
            if (rental != null)
                return errorMessage = ($"Driving License {carRental.DrivingLicenceNo} is already occupied with active rental.");
            
            if (carRental.PickUpDate == carRental.DropDate || carRental.PickUpDate > carRental.DropDate)
                return errorMessage = "Drop Date/Time Should Be Greater Than PickUp Date/Time.";
            else if (carRental.DropDate - carRental.PickUpDate < TimeSpan.FromHours(2))
                return errorMessage = " At least car should be rented for minimum duration of 2 hours.";

            if (!(carRental.Cost > 0))
                return errorMessage = "Rental Cost Should Not Be Zero.";

            return errorMessage;
        }
    
    }
   
}
