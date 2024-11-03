using LogisticApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApp.Controllers
{
    public class DetailedOrderController : Controller
    {
        private readonly LogisticAppContext _context;
        public DetailedOrderController(LogisticAppContext context)
        {
            _context = context;
        }
        public IActionResult Index(string orderId)
        {
            Order clickedOrder = _context.Orders.Single(o => o.Id == Guid.Parse(orderId));
            ViewBag.CurrentOrder = clickedOrder;
            return View("~/Views/DetailedOrder.cshtml");
        }
    }
}
