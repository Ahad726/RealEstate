using Microsoft.AspNetCore.Mvc;

namespace RealState.Controllers
{
    public class PlotBooking : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
