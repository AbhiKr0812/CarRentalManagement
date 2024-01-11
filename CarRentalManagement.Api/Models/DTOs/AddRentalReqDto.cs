using CarRentalManagement.Api.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class AddRentalReqDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Name has to be a minimum of 3 characters")]
        [MaxLength(100, ErrorMessage = "Color has to be a maximum of 100 characters")]
        public string CustomerName { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "Name has to be a minimum of 10 characters")]
        [MaxLength(11, ErrorMessage = "Name has to be a maximum of 10 characters")]
        public string DrivingLicenceNo { get; set; }

        [Required]
        public DateTime PickUpDate { get; set; }

        [Required]
        public DateTime DropDate { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public decimal Cost { get; set; }
        [Required]
        public bool CompletionStatus { get; set; } = false;
        
       
    }
}
