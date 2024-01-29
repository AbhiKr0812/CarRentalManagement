namespace CarRentalManagement.Api.Models.DTOs
{
    public class ModelGetDto
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
