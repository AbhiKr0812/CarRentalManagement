using AutoMapper;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;
using CarRentalManagement.Api.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarMakesController : ControllerBase
    {
        private readonly ICarMakeRepository _makeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CarMakesController> _logger;

        public CarMakesController(ICarMakeRepository makeRepository,
            IMapper mapper, ILogger<CarMakesController> logger)
        {
            _makeRepository = makeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        #region Get All Car Make
        [HttpGet]
        public async Task<IActionResult> GetAllMakes()
        {
            // Get Makes from db - DoaminModel
            var makes = await _makeRepository.GetAllMakesAsync();

            // Map DomainModel to Dto
            return Ok(_mapper.Map<List<MakeGetDto>>(makes));

        }
        #endregion

        #region Get Single Car Make
        [HttpGet]
        [Route("{makeId:int}")]
        public async Task<IActionResult> GetMakeById([FromRoute] int makeId)
        {
            // DomainModel
            var make = await _makeRepository.GetMakeByIdAsync(makeId);

            // Dto
            return Ok(_mapper.Map<MakeGetDto>(make));
        }

        #endregion

        #region Add A Car Make
        [HttpPost]
        public async Task<IActionResult> CreateMake([FromBody] MakePostPutDto makePostDto)
        {
            // Map PostDto to Domain
            var newMake = _mapper.Map<CarMake>(makePostDto);

            // Use Domain to create Make
             newMake = await _makeRepository.CreateMakeAsync(newMake);

            // Map Domain to GetDto
            var makeGetDto = _mapper.Map<MakeGetDto>(newMake);

            _logger.LogInformation($" New Make : {JsonSerializer.Serialize(newMake)} Got Added Successfully");
            return CreatedAtAction(nameof(GetMakeById), new { newMake.MakeId }, makeGetDto);
        }
        #endregion

        #region Update A Make
        [HttpPut]
        [Route("{makeId:int}")]
        public async Task<IActionResult> UpdateMake([FromRoute] int makeId, 
            [FromBody] MakePostPutDto makePutDto)
        {
            // Map Dto to Domain
            var makeToBeUpdate = _mapper.Map<CarMake>(makePutDto);

            // Use Domain to update
            var updatedMake = await _makeRepository.UpdateMakeAsync(makeId, makeToBeUpdate);

            // Map to GetDto
            _logger.LogInformation($"Existing Make : {JsonSerializer.Serialize(updatedMake)} Got Updated Successfully");
            return Ok(_mapper.Map<MakeGetDto>(updatedMake));
        }

        #endregion

        #region Delete A Make
        [HttpDelete]
        [Route("{makeId:int}")]
        public async Task<IActionResult> DeleteMake([FromRoute] int makeId)
        {
            var deletedMake = await _makeRepository.DeleteMakeAsync(makeId);

            _logger.LogInformation($"Existing Make : {JsonSerializer.Serialize(deletedMake)} Got Deleted Successfully");

            // Map to GetDto
            return Ok(_mapper.Map<MakeGetDto>(deletedMake));
        }

        #endregion

        #region Get A Make Models
        [HttpGet]
        [Route("{makeId:int}/models")]
        public async Task<IActionResult> GetAllMakeModels([FromRoute] int makeId)
        {
            // Get Makes from db - DoaminModel
            var models = await _makeRepository.GetAllMakeModelsAsync(makeId);

            // Map DomainModel to Dto
            return Ok(_mapper.Map<List<ModelGetDto>>(models));

        }
        #endregion

        #region Get A Make Model
        [HttpGet]
        [Route("{makeId:int}/models/{modelId:int}")]
        public async Task<IActionResult> GetMakeModelById([FromRoute] int makeId, int modelId)
        {
            // DomainModel
            var model = await _makeRepository.GetMakeModelByIdAsync(makeId,modelId);

            // Dto
            return Ok(_mapper.Map<ModelGetDto>(model));
        }

        #endregion

        #region Add A Model To Make
        [HttpPost]
        [Route("{makeId:int}/models")]
        public async Task<IActionResult> CreateMakeModel([FromRoute] int makeId, [FromBody] ModelPostPutDto modelPostDto)
        {
            // Map PostDto to Domain
            var model = _mapper.Map<CarModel>(modelPostDto);

            // Use Domain to create Make
            var addedModel = await _makeRepository.CreateMakeModelAsync(makeId, model);

            // Map Domain to GetDto
            var newModel = _mapper.Map<ModelGetDto>(addedModel);

            _logger.LogInformation($" New Model : {JsonSerializer.Serialize(newModel)} Got Added Successfully");
            return CreatedAtAction(nameof(GetMakeModelById), new {makeId,newModel.ModelId }, newModel);
        }
        #endregion

        #region Update A Make's Model
        [HttpPut("{makeId:int}/models/{modelId:int}")]
        public async Task<IActionResult> UpdateMakeModel([FromRoute] int makeId,
           int modelId, [FromBody] ModelPostPutDto modelPutDto)
        {
            // Map Dto to Domain
            var modelToBeUpdate = _mapper.Map<CarModel>(modelPutDto);

            // Use Domain to update
            var updatedModel = await _makeRepository.UpdateMakeModelAsync(makeId,modelId,modelToBeUpdate);

            // Map to GetDto
            _logger.LogInformation($"Existing Model : {JsonSerializer.Serialize(updatedModel)} Got Updated Successfully");
            return Ok(_mapper.Map<ModelGetDto>(updatedModel));
        }

        #endregion

        #region Delete A Make's Model
        [HttpDelete]
        [Route("{makeId:int}/models/{modelId:int}")]
        public async Task<IActionResult> DeleteMakeModel([FromRoute] int makeId, int modelId)
        {
            var deletedModel = await _makeRepository.DeleteMakeModelAsync(makeId,modelId);

            _logger.LogInformation($"Existing Model : {JsonSerializer.Serialize(deletedModel)} Got Deleted Successfully");

            // Map to GetDto
            return Ok(_mapper.Map<ModelGetDto>(deletedModel));
        }

        #endregion

    }
}
