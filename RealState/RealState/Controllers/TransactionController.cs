using Microsoft.AspNetCore.Mvc;

namespace RealState.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateExpense()
        {
            return View();
        }
    }
}
