using LogisticApp.Model;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace LogisticApp.Controllers
{
    public class OrderFormController : Controller
    {
        private readonly LogisticAppContext _context;
        public OrderFormController(LogisticAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/OrderForm.cshtml");
        }

        [HttpGet]
        public IActionResult GetSuggestedCities()
        {
            string cityName = HttpContext.Request.Query["term"].ToString();
            List<string> suggestedNames = _context.Cities
                .Where(c => Regex.IsMatch(c.Name, @"" + cityName))
                .Select(c => c.Name)
                .ToList();

            return Ok(suggestedNames);
        }

        [HttpGet]
        public IActionResult GetSuggestedAddresses()
        {
            NameValueCollection test = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.ToString());
            string? cityName = test["city"];
            //if (cityName == null)
            //not ok

            string? inputAddress = test["address"];

            List<City> cities = _context.Cities
            .Where(c => Regex.IsMatch(c.Name, @"" + cityName))
            .ToList();

            List<string> allAddresses = new List<string>();
            foreach (City city in cities)
            {
                foreach (Street street in city.Streets)
                {
                    foreach (House house in street.Houses)
                    {
                         allAddresses.Add(house.BuildFullAddress());
                    }
                }
            }

            List<string> suggestedAddresses = allAddresses
                .Where(fullAddressString => Regex.IsMatch(fullAddressString, @"" + inputAddress))
                .ToList();

            return Ok(suggestedAddresses);
        }

        [HttpPost]
        public IActionResult CreateOrder(IFormCollection form)
        {
            string? senderFullInCityAddress = form["sender_address"];
            Dictionary<string, string> senderAddressComponents = Address.SplitInCityAddressString(senderFullInCityAddress);

            string? recipientFullAddress = form["recipient_address"];
            Dictionary<string, string> recipientAddressComponents = Address.SplitInCityAddressString(recipientFullAddress);

            string? orderCreationDtm = form["order_creation_dtm"];
            string? cargoWeightInGrams = form["cargo_weight_in_grams"];

            Postcode senderPostcode = _context.Postcodes.Single(pc => pc.Code == senderAddressComponents["postcode"]);
            Postcode recipientPostcode = _context.Postcodes.Single(pc => pc.Code == recipientAddressComponents["postcode"]);

            Address senderAddress = new Address(senderPostcode, senderAddressComponents["house"]);
            Address recipientAddress = new Address(recipientPostcode, recipientAddressComponents["house"]);

            Order order = new Order {
                SenderAdress = senderAddress,
                RecipientAddress = recipientAddress,
                CreationDtm = DateTime.Parse(orderCreationDtm),
                DisplayId = $"O-{1000 + _context.Orders.Count()}",
                CargoWeightInGrams = int.Parse(cargoWeightInGrams) };
            
            _context.Addresses.Add(senderAddress);
            _context.Addresses.Add(recipientAddress);
            _context.Orders.Add(order);

            return Redirect("~/Views/Home/Index.cshtml");
        }
    }
}
