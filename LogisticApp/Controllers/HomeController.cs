using Microsoft.AspNetCore.Mvc;

namespace LogisticApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
