using LogisticApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApp.Controllers
{
    public class OrderListController : Controller
    {
        private readonly LogisticAppContext _context;
        public OrderListController(LogisticAppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Orders = _context.Orders.ToList();
            return View("~/Views/OrderList.cshtml");
        }
    }
}
