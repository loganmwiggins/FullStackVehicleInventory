using Microsoft.AspNetCore.Mvc;
using VehicleInventoryProj.Models;
using System.Linq;

namespace VehicleInventoryProj.Controllers
{
    public class MatchController : Controller
    {
        private readonly AppDbContext _context;

        public MatchController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FindYourMatch()
        {
            // Load the form for users to fill out
            return View();
        }

        [HttpPost]
        public IActionResult ProcessMatch()
        {
            var vehicleType = Request.Form["VehicleType"].ToString();
            var drivingEnvironment = Request.Form["DrivingEnvironment"].ToString();
            var fuelType = Request.Form["FuelType"].ToString();
            var budget = Request.Form["Budget"].ToString();
            var passengers = Request.Form["Passengers"].ToString();

            var vehicles = _context.Vehicles.AsQueryable();

            // Apply filtering based on answers
            if (!string.IsNullOrEmpty(vehicleType))
            {
                switch (vehicleType)
                {
                    case "Space":
                        vehicles = vehicles.Where(v => v.Build == "Truck" || v.Build == "SUV");
                        break;
                    case "Performance":
                        vehicles = vehicles.Where(v => v.Build == "Sedan" || v.Build == "Truck");
                        break;
                    case "Luxury":
                        vehicles = vehicles.Where(v => v.Build == "Sedan" || v.Build == "SUV");
                        break;
                }
            }

            if (!string.IsNullOrEmpty(drivingEnvironment))
            {
                switch (drivingEnvironment)
                {
                    case "City":
                        vehicles = vehicles.Where(v => v.Build == "Sedan" || v.FuelType == "Hybrid");
                        break;
                    case "Off-road":
                        vehicles = vehicles.Where(v => v.Build == "Truck" || v.Build == "SUV");
                        break;
                    case "Highway":
                        vehicles = vehicles.Where(v => v.Build == "Sedan" && v.HwyMPG.HasValue && v.HwyMPG > 30);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(fuelType))
            {
                vehicles = vehicles.Where(v => v.FuelType == fuelType);
            }

            if (!string.IsNullOrEmpty(budget))
            {
                switch (budget)
                {
                    case "Under20k":
                        vehicles = vehicles.Where(v => v.MSRP < 20000);
                        break;
                    case "20kTo40k":
                        vehicles = vehicles.Where(v => v.MSRP >= 20000 && v.MSRP <= 40000);
                        break;
                    case "Above40k":
                        vehicles = vehicles.Where(v => v.MSRP > 40000);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(passengers))
            {
                switch (passengers)
                {
                    case "JustMe":
                        vehicles = vehicles.Where(v => v.Build == "Sedan");
                        break;
                    case "1To3":
                        vehicles = vehicles.Where(v => v.Build == "Sedan" || v.Build == "SUV");
                        break;
                    case "4To7":
                        vehicles = vehicles.Where(v => v.Build == "SUV" || v.Build == "Truck");
                        break;
                }
            }

            // Return filtered vehicles with the "source" query parameter
            var filteredVehicles = vehicles.ToList();
            ViewBag.Source = "match";  // Pass a source parameter indicating the source is the "Find Your Match" feature
            return View("MatchResults", filteredVehicles);
        }
    }
}