using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleInventoryProj.Models;

namespace VehicleInventoryProj.Controllers
{
    public class ManageController : Controller
    {
        private readonly ILogger<ManageController> _logger;
        private readonly AppDbContext _context; // Provide access to model  

        public ManageController(ILogger<ManageController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // View Routing
        [HttpGet("/manage")]
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

            // Pass the filtered vehicles and dropdown options via ViewBag
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

            return View(ViewBag.Vehicles);
        }


        [HttpGet("/manage/{vehicleId?}")]
        public async Task<IActionResult> EditVehicle(int? vehicleId)
        {
            if (vehicleId == null)
            {
                return View(new Vehicle
                {
                    VehicleId = 0,
                    Make = string.Empty,
                    Model = string.Empty,
                    Year = DateTime.Now.Year,
                    Build = "Sedan",
                    FuelType = "Gas",
                    MSRP = 0,
                    ImgPath = string.Empty,
                    CityMPG = 0,
                    HwyMPG = 0,
                    InStock = false
                });
            }

            Vehicle? vehicle = await _context.Vehicles.FindAsync(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }




        // CRUD Functionality
        [HttpPost]
        public async Task<IActionResult> SubmitVehicle(Vehicle vehicle)
        {
            // Validate for no image path
            if (string.IsNullOrEmpty(vehicle.ImgPath))
            {
                vehicle.ImgPath = "assets/null-car.png";
            }

            // Add new vehicle
            if (vehicle.VehicleId == 0)
            {
                _context.Vehicles.Add(vehicle);
            }
            // Update existing vehicle
            else
            {
                _context.Vehicles.Update(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(int vehicleId) 
        {
            Vehicle? vehicle = await _context.Vehicles.FindAsync(vehicleId);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}