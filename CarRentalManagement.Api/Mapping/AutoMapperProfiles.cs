using AutoMapper;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;

namespace CarRentalManagement.Api.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<Car, CarGetDto>().ReverseMap();
            CreateMap<CarPostPutDto, Car>().ReverseMap();

            CreateMap<CarRentalRecord, CarRentalRecordDto>().ReverseMap();
            CreateMap<AddRentalReqDto,CarRentalRecord>().ReverseMap();
            CreateMap<UpdateRentalRecord, CarRentalRecord>().ReverseMap();

            CreateMap<AddRentalReqDto,ClosedRentals>().ReverseMap();
            CreateMap<ClosedRentals, CarRentalRecordDto>().ReverseMap();

            CreateMap<CarMake, MakeGetDto>().ReverseMap();
            CreateMap<MakePostPutDto, CarMake>().ReverseMap();
            CreateMap<CarModel, ModelGetDto>().ReverseMap();
            CreateMap<ModelPostPutDto, CarModel>().ReverseMap();
        }
    }
}
