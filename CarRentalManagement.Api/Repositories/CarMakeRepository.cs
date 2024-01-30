using CarRentalManagement.Api.Data;
using CarRentalManagement.Api.Exceptions;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagement.Api.Repositories
{
    public class CarMakeRepository : ICarMakeRepository
    {
        private readonly CarRentalDbContext _carRentalDb;

        public CarMakeRepository(CarRentalDbContext carRentalDb)
        {
            _carRentalDb = carRentalDb;
        }
        public async Task<CarMake> CreateMakeAsync(CarMake make)
        {
            await _carRentalDb.CarMakes.AddAsync(make);
            await _carRentalDb.SaveChangesAsync();
            return make;
        }

        public async Task<CarModel> CreateMakeModelAsync(int makeId, CarModel modelToBeAdded)
        {
            var make = await _carRentalDb.CarMakes.Include(m => m.Models).
                FirstOrDefaultAsync(m => m.MakeId == makeId);
            if (make == null)
                throw new NotFoundException("Car Make Doesn't Exist");
            make.Models.Add(modelToBeAdded);

            await _carRentalDb.SaveChangesAsync();
            return modelToBeAdded;

        }

        public async Task<CarMake?> DeleteMakeAsync(int id)
        {
            var makeToBeDeleted = await _carRentalDb.CarMakes.
                FirstOrDefaultAsync(m => m.MakeId == id);
            if (makeToBeDeleted == null)
                throw new NotFoundException("Car Make Doesn't Exist");
            _carRentalDb.Remove(makeToBeDeleted);

            await _carRentalDb.SaveChangesAsync() ;
            return makeToBeDeleted;
        }

        public async Task<CarModel?> DeleteMakeModelAsync(int makeId, int modelId)
        {
            var modelToBeDeleted = await _carRentalDb.CarModels.
                FirstOrDefaultAsync(m => m.MakeId == makeId && m.ModelId == modelId );
            if (modelToBeDeleted == null)
                throw new NotFoundException($"Model does not exist.");
            _carRentalDb.CarModels.Remove(modelToBeDeleted);

            await _carRentalDb.SaveChangesAsync();
            return modelToBeDeleted;
        }

        public async Task<List<CarMake>> GetAllMakesAsync()
        {
            var makes = await _carRentalDb.CarMakes.ToListAsync();
            if (makes.Count == 0)
                throw new NotFoundException("There is no make available at this moment ");
            return makes;
        }

        public async Task<List<CarModel>> GetAllMakeModelsAsync(int makeId)
        {
            var models = await _carRentalDb.CarModels.Where(m  => m.MakeId == makeId).ToListAsync();
            if (models.Count == 0)
                throw new NotFoundException($"There is no model exist for make id: {makeId}");
            return models;

        }

        public async Task<CarMake?> GetMakeByIdAsync(int id)
        {
            var make = await _carRentalDb.CarMakes.FirstOrDefaultAsync(m => m.MakeId ==  id);
            if (make == null)
                throw new NotFoundException($"There is no make exist with the id: {id}");
            return make;
        }

        public async  Task<CarModel?> GetMakeModelByIdAsync(int makeId, int modelId)
        {
            var model = await _carRentalDb.CarModels.
                FirstOrDefaultAsync(m => m.MakeId == makeId && m.ModelId == modelId);
            if (model == null)
                throw new NotFoundException($"Model does not exist.");
            return model;
        }

        public async Task<CarMake?> UpdateMakeAsync(int id, CarMake make)
        {
            var existingMake = await _carRentalDb.CarMakes.FirstOrDefaultAsync(m => m.MakeId == id);
            if (existingMake == null)
                throw new NotFoundException($"Make with id : {id} doesn't exist"); 

            existingMake.Name = make.Name;
            
            await _carRentalDb.SaveChangesAsync();
            return existingMake;
        }

        public async Task<CarModel?> UpdateMakeModelAsync(int makeId,int modelId, CarModel modelToBeUpdate)
        {
            var existingModel = await _carRentalDb.CarModels.
                FirstOrDefaultAsync(m => m.MakeId == makeId && m.MakeId == modelId);
            if (existingModel == null)
                throw new NotFoundException("Model doesn't exist");

            existingModel.Name = modelToBeUpdate.Name;
            existingModel.IsAvailable = modelToBeUpdate.IsAvailable;

            await _carRentalDb.SaveChangesAsync();
            return existingModel;
        }
    }
}
