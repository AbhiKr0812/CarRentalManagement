using CarRentalManagement.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Api.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        // Adding Existing Entities(Car.cs & CarRentalRecord.cs) as collection
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarRentalRecord> CarRentalRecords { get; set; }
        public DbSet<ClosedRentals> ClosedRentals { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
    }
}
