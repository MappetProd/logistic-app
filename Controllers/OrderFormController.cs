using LogisticApp.Model;
using LogisticApp.ViewModels;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var suggestedNames = _context.Cities
                .Where(c => EF.Functions.Like(c.Name, $"%{cityName}%"))
                .Select(c => c.Name).ToList();


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
            .Where(c => EF.Functions.Like(c.Name, $"%{cityName}%"))
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
                .Where(fullAddressString => Regex.IsMatch(fullAddressString, @"" + inputAddress, RegexOptions.IgnoreCase))
                .ToList();

            return Ok(suggestedAddresses);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dictionary<string, string>? senderAddressComponents = Address.SplitInCityAddressString(model.SenderFullInCityAddress);
            Dictionary<string, string>? recipientAddressComponents = Address.SplitInCityAddressString(model.RecipientFullInCityAddress);
            
            Postcode senderPostcode;
            Postcode recipientPostcode;
            try
            {
                senderPostcode = _context.Postcodes.Single(pc => pc.Code == senderAddressComponents["postcode"]);
                recipientPostcode = _context.Postcodes.Single(pc => pc.Code == recipientAddressComponents["postcode"]);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            Address senderAddress = new Address(senderPostcode, senderAddressComponents["house"]);
            Address recipientAddress = new Address(recipientPostcode, recipientAddressComponents["house"]);

            Order order = new Order
            {
                SenderAddressId = senderAddress.Id,
                RecipientAddressId = recipientAddress.Id,
                CreationDtm = model.CreationDtm.ToUniversalTime(),
                DisplayId = $"O-{1000 + _context.Orders.Count()}",
                CargoWeightInGrams = (int)(model.CargoWeightInKilograms * 1000)
            };

            _context.Addresses.Add(senderAddress);
            _context.Addresses.Add(recipientAddress);
            _context.Orders.Add(order);
            _context.SaveChanges();

            return View("~/Views/Home/Index.cshtml");
        }
    }
}
