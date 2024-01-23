using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.Domain
{
    public class CarMake
    {
        [Key]
        public int MakeId { get; set; }
        public string Name { get; set; }

        public List<CarModel> Models { get; set; }
    }
}
