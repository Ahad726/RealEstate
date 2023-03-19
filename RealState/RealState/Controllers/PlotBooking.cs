using Microsoft.AspNetCore.Mvc;
using RealState.Models.PlotBooking;

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

        [HttpPost]
        public IActionResult Create(PlotBookingModel plotBookingModel)
        {
            return View();
        }
    }
}
