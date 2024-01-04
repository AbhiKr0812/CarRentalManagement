using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class AddCarRequestDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(50, ErrorMessage = "Color has to be a maximum of 50 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(15, ErrorMessage = "Color has to be a maximum of 15 characters")]
        public string Color { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Name has to be a minimum of 10 characters")]
        [MaxLength(10, ErrorMessage = "Name has to be a maximum of 10 characters")]
        public string LicensePlateNumber { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(15, ErrorMessage = "Color has to be a maximum of 15 characters")]
        public string Make { get; set; }
        public bool Availability { get; set; } = true;
    }
}
