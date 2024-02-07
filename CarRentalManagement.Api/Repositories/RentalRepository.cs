using AutoMapper;
using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Exceptions;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Api.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly CarRentalDbContext _carRentalDb;
        private readonly IMapper _mapper;

        public RentalRepository(CarRentalDbContext carRentalDb, IMapper mapper)
        {
            _carRentalDb = carRentalDb;
            _mapper = mapper;
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
            var rentals = await _carRentalDb.CarRentalRecords.ToListAsync();
            if (rentals.Count == 0)
                return new List<CarRentalRecord>();
                
            foreach (var rental in rentals)
            {
                var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id .Equals(rental.VehicleId));
                rental.CarName = car.Model + " " + car.Color + "-" + car.LicensePlateNumber;
            }
            return rentals;
        }

        public async Task<List<ClosedRentals>> GetClosedRentalsAsync()
        {
            var rentals = await _carRentalDb.ClosedRentals.ToListAsync();
            if (rentals.Count == 0)
                return new List<ClosedRentals> ();
            foreach (var rental in rentals)
            {
                var car = await _carRentalDb.Cars.FirstOrDefaultAsync(c => c.Id.Equals(rental.VehicleId));
                rental.CarName = car.Model + " " + car.Color;
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

            // Add to ClosedRentals and Delete From Open Rentals
            if (record.CompletionStatus == true)
            {
                var updatedRental = _mapper.Map<AddRentalReqDto>(existingRecord);
                await _carRentalDb.ClosedRentals.AddAsync(_mapper.Map<ClosedRentals>(updatedRental));

                _carRentalDb.CarRentalRecords.Remove(existingRecord);
            }

            await _carRentalDb.SaveChangesAsync();
            return existingRecord;

        }

        public async Task<ClosedRentals?> DeleteAsync(int id)
        {
            var existingRecord = await _carRentalDb.ClosedRentals.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRecord == null)
                throw new NotFoundException($"There Is No Such Record Present With The Id: {id}");

            _carRentalDb.ClosedRentals.Remove(existingRecord);
            await _carRentalDb.SaveChangesAsync();
            return existingRecord;

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
            else if (carRental.DropDate - carRental.PickUpDate > TimeSpan.FromHours(72))
                    return errorMessage = "A Car can not be rented for more than 72 hours.";

            if (!(carRental.Cost > 0))
                return errorMessage = "Rental Cost Should Not Be Zero.";

            return errorMessage;
        }
    
    }
   
}
