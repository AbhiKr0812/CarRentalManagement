using CarRentalManagement.Api.Models.Domain;

namespace CarRentalManagement.Api.Repositories.IRepositories
{
    public interface ICarMakeRepository
    {
        Task<List<CarMake>> GetAllMakesAsync();
        Task<CarMake?> GetMakeByIdAsync(int id);
        Task<CarMake> CreateMakeAsync(CarMake make);
        Task<CarMake?> UpdateMakeAsync(int id, CarMake make);
        Task<CarMake?> DeleteMakeAsync(int id);

        Task<List<CarModel>> GetAllMakeModelsAsync(int makeId);
        Task<CarModel?> GetMakeModelByIdAsync(int makeId, int modelId);
        Task<CarModel> CreateMakeModelAsync(int makeId,CarModel modelToBeAdded);
        Task<CarModel?> UpdateMakeModelAsync(int makeId, int modelId, CarModel modelToBeUpdate);
        Task<CarModel?> DeleteMakeModelAsync(int makeId, int modelId);

    }
}
