using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RealState.Models.TransactionModels;
using System.IO;
using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using RealState.Models;

namespace RealState.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public TransactionController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                var trasacModel = new TransactionUM();
                string webRootPath = _hostEnvironment.WebRootPath;

                if (transactionModel.ImageFile != null && transactionModel.ImageFile.Length > 0)
                {

                    string fileName = transactionModel.ImageFile.FileName;
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await transactionModel.ImageFile.CopyToAsync(fileStream);
                    }

                    transactionModel.ImageUrl = fileName;
                }


                trasacModel.AddExpense(transactionModel);
                return RedirectToAction("GetExpenses");

            }
            return View(transactionModel);
        }

        [HttpGet]
        public IActionResult CreateIncome()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncome(TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {

                var trasacModel = new TransactionUM();
                string webRootPath = _hostEnvironment.WebRootPath;

                if (transactionModel.ImageFile != null && transactionModel.ImageFile.Length > 0)
                {

                    string fileName = Guid.NewGuid().ToString();
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await transactionModel.ImageFile.CopyToAsync(fileStream);
                    }

                    transactionModel.ImageUrl = fileName;
                }


                trasacModel.AddIncome(transactionModel);
                return RedirectToAction("Index");

            }
            return View(transactionModel);
        }

        [HttpGet]
        public IActionResult GetAllExpense()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var transacModel = new TransactionVM();
            var transactions = transacModel.GetExpenses(tableModel);
            return Json(transactions);
        }

    }
}
