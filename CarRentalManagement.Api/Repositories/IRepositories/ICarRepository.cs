using CarRentalManagement.Api.Models.Domain;

namespace CarRentalManagement.Api.Repositories.IRepositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllAsync();

        Task<Car?> GetByIdAsync(int id);

        Task<Car> CreateAsync(int makeId, int modelId, Car car);

        Task<Car?> UpdateAsync(int id, Car car);

        Task<Car?> ShuffleCarAvailabilityAsync(int id);

        Task<Car?> DeleteAsync(int id);
    }
}
