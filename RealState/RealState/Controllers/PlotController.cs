using Microsoft.AspNetCore.Mvc;
using RealState.Models.BlockModels;
using RealState.Models;

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
            var model = new BlockViewModel();
            var plots = model.GetBlocks(tableModel);
            return Json(plots);
        }
    }
}
