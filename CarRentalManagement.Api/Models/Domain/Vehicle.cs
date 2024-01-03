namespace CarRentalManagement.Api.Models.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Make { get; set; }
        public string Colour { get; set; }
        public bool Availability { get; set; }
    }
}
