using CarRentalManagement.Api.Models.Domain;

namespace CarRentalManagement.Api.Repositories.IRepositories
{
    public interface IMakeRepository
    {
        Task<List<CarMake>> GetAllAsync();

        Task<CarMake?> GetByIdAsync(int id);

        Task<CarMake> CreateAsync(CarMake make);

        Task<CarMake?> UpdateAsync(int id, CarMake make);

        Task<CarMake?> DeleteAsync(int id);
    }
}
