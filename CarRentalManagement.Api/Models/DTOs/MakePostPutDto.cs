using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class MakePostPutDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Car Make Name should be a minimum of 4 characters")]
        [MaxLength(24, ErrorMessage = "Car Make Name should be a maximum of 24 characters")]
        public string Name { get; set; }
    }
}
