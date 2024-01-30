using CarRentalManagement.Api.Models.Domain;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class CarGetDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlateNumber { get; set; }
        public bool Availability { get; set; }
    }
}
