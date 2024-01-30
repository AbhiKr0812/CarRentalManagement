using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.Domain
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlateNumber { get; set; }       
        public bool Availability { get; set; }
    }
}
