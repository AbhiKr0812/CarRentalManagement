using AutoMapper;
using CarRentalManagement.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly CarRentalDbContext _carRentalDb;
        private readonly IMapper _mapper;

        public RentalsController(CarRentalDbContext carRentalDb, IMapper mapper)
        {
            _carRentalDb = carRentalDb;
            _mapper = mapper;
        }
    }
}
