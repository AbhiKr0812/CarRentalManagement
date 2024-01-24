using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class MakePostPutDto
    {
        [Required]
        public string Name { get; set; }
    }
}
