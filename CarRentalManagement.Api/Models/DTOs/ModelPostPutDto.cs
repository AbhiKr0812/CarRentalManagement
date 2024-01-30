using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class ModelPostPutDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Car Model Name should be a minimum of 4 characters")]
        [MaxLength(50, ErrorMessage = "Car Model Name should be a maximum of 50 characters")]
        public string Name { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
