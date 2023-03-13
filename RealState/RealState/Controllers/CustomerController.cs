using Microsoft.AspNetCore.Mvc;
using RealState.Models;
using RealState.Models.CustomerModels;

namespace RealState.Controllers
{
    public class CustomerController : Controller
    {
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
        [ValidateAntiForgeryToken]
        public IActionResult Add(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var model = new CustomerUpdateModel();
                model.AddNewCustomer(customer);
                return RedirectToAction(nameof(CustomerController.Index));
            }
            return View(customer);
        }

        public IActionResult GetCustomers()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerViewModel();
            var data = model.GetCustomers(tableModel);
            return Json(data);
        }
    }
}
