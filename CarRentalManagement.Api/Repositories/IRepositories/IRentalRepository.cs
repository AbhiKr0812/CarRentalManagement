using CarRentalManagement.Api.Models.Domain;

namespace CarRentalManagement.Api.Repositories.IRepositories
{
    public interface IRentalRepository
    {
        Task<List<CarRentalRecord>> GetOpenRentalsAsync();

        Task<List<CarRentalRecord>> GetClosedRentalsAsync();

        Task<CarRentalRecord?> GetByIdAsync(int id);

        Task<CarRentalRecord> CreateAsync(CarRentalRecord record);

        Task<CarRentalRecord?> UpdateAsync(int id, CarRentalRecord record);

        Task<CarRentalRecord?> ApproveCompletion(int id);

        Task<CarRentalRecord?> DeleteAsync(int id);
    }
}
