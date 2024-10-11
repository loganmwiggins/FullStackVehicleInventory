using Microsoft.AspNetCore.Mvc;
using VehicleInventoryProj.Models;
using System.Linq;

namespace VehicleInventoryProj.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly AppDbContext _context; // Provide access to model  

        public VehiclesController(ILogger<VehiclesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        // Action to handle GET requests to /vehicles
        // Retrieves a list of all vehicles from the database and returns it to the view

        [HttpGet("/vehicles")]
        public IActionResult Index(string make, string model, string year, string build, string fuelType)
        {
            // Get all vehicles from the database
            var allVehicles = _context.Vehicles.ToList();

            // Get the distinct makes, models, years, builds, and fuel types for the dropdowns
            var makes = allVehicles.Select(v => v.Make).Distinct().ToList();
            var models = allVehicles.Select(v => v.Model).Distinct().ToList();
            var years = allVehicles.Select(v => v.Year.ToString()).Distinct().ToList();
            var builds = allVehicles.Select(v => v.Build).Distinct().ToList();
            var fuelTypes = allVehicles.Select(v => v.FuelType).Distinct().ToList();

            // Filter the vehicle list based on the user's selection
            var filteredVehicles = allVehicles.AsQueryable();

            if (!string.IsNullOrEmpty(make))
            {
                filteredVehicles = filteredVehicles.Where(v => v.Make == make);
            }

            if (!string.IsNullOrEmpty(model))
            {
                filteredVehicles = filteredVehicles.Where(v => v.Model == model);
            }

            if (!string.IsNullOrEmpty(year))
            {
                filteredVehicles = filteredVehicles.Where(v => v.Year.ToString() == year);
            }

            if (!string.IsNullOrEmpty(build))
            {
                filteredVehicles = filteredVehicles.Where(v => v.Build == build);
            }

            if (!string.IsNullOrEmpty(fuelType))
            {
                filteredVehicles = filteredVehicles.Where(v => v.FuelType == fuelType);
            }

            // Pass the filtered vehicles and dropdown options
            ViewBag.Vehicles = filteredVehicles.ToList();
            ViewBag.Makes = makes;
            ViewBag.Models = models;
            ViewBag.Years = years;
            ViewBag.Builds = builds;
            ViewBag.FuelTypes = fuelTypes;

            // Pass the selected values back to the view to retain the selected filter
            ViewBag.SelectedMake = make;
            ViewBag.SelectedModel = model;
            ViewBag.SelectedYear = year;
            ViewBag.SelectedBuild = build;
            ViewBag.SelectedFuelType = fuelType;

            return View();
        }


        // Action to handle GET requests to /vehicles/{vehicle_id}
        // Retrieves details of a specific vehicle based on its vehicle_id
        [HttpGet("/vehicles/{vehicle_id}")]
        public IActionResult VehicleDetail(int vehicle_id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(m => m.VehicleId == vehicle_id);

            if (vehicle == null) return NotFound();

            var color = vehicle.ColorId.HasValue
                ? _context.Colors.FirstOrDefault(c => c.ColorId == vehicle.ColorId)
                : null;

            ViewBag.Color = color;
            ViewBag.Vehicle = vehicle;
            return View();
        }
    }
}
