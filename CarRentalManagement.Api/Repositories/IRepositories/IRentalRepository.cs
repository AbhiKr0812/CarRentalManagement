using CarRentalManagement.Api.Models.Domain;

namespace CarRentalManagement.Api.Repositories.IRepositories
{
    public interface IRentalRepository
    {
        Task<List<CarRentalRecord>> GetAllAsync();

        Task<CarRentalRecord?> GetByIdAsync(int id);

        Task<CarRentalRecord> CreateAsync(CarRentalRecord record);

        Task<CarRentalRecord?> UpdateAsync(int id, CarRentalRecord record);

        Task<CarRentalRecord?> DeleteAsync(int id);
    }
}
