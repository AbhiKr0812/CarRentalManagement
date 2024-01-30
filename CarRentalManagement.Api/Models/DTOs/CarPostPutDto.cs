using CarRentalManagement.Api.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class CarPostPutDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Color Name should be a minimum of 3 characters")]
        [MaxLength(15, ErrorMessage = "Color Name should be a maximum of 15 characters")]
        public string Color { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "License Plate No should be a minimum of 10 characters")]
        [MaxLength(10, ErrorMessage = "License Plate No should be a maximum of 10 characters")]
        public string LicensePlateNumber { get; set; }

        [Required]
        public bool Availability { get; set; }
    }
}
