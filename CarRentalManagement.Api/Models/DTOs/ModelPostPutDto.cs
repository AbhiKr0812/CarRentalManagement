using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class ModelPostPutDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
