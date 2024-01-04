using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.Api.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
