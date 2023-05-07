using Microsoft.AspNetCore.Mvc;

namespace RealState.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Income()
        {
            return View();
        }
    }
}
