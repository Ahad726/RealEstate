using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealState.Core.Entity;
using RealState.Models.BlockModels;

namespace RealState.Controllers
{
    public class BlockController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BlockController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BlockModel blockModel)
        {
            if (ModelState.IsValid)
            {
                var blockUpdateModel = new BlockUpdateModel();
                blockUpdateModel.AddNewBlock(blockModel);
                return RedirectToAction(nameof(BlockController.Index));
            }
            return View(blockModel);
        }


    }
}
