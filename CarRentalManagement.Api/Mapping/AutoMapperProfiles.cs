using AutoMapper;
using CarRentalManagement.Api.Models.Domain;
using CarRentalManagement.Api.Models.DTOs;

namespace CarRentalManagement.Api.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<AddCarRequestDto, Car>().ReverseMap();
            CreateMap<UpdateCarReqDto, Car>().ReverseMap(); 

            CreateMap<CarRentalRecord, CarRentalRecordDto>().ReverseMap();
            CreateMap<AddRentalReqDto,CarRentalRecord>().ReverseMap();
            CreateMap<UpdateRentalRecord, CarRentalRecord>().ReverseMap();
        }
    }
}
