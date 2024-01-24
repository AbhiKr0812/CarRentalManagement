using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.Domain
{
    public class CarModel
    {
        [Key]
        public int ModelId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public int MakeId { get; set; }
        public CarMake Make { get; set; }
    }
}
