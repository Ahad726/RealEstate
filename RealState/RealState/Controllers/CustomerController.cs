using Microsoft.AspNetCore.Mvc;
using RealState.Models.CustomerModels;

namespace RealState.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                var model = new CustomerUpdateModel();
                model.AddNewCustomer(customer);
                return View(nameof(Index));

            }

            return View(customer);
        }
    }
}
