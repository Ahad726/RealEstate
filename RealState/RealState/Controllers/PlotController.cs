using Microsoft.AspNetCore.Mvc;
using RealState.Models.BlockModels;
using RealState.Models;
using RealState.Models.PlotModels;

namespace RealState.Controllers
{
    public class PlotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPlots()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new PlotViewModel();
            var plots = model.GetPlots(tableModel);
            return Json(plots);
        }
    }
}
