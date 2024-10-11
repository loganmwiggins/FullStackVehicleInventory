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
        public IActionResult Index()
        {
            List<Vehicle> allVehicles = _context.Vehicles.ToList();

            return View(allVehicles);
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
                    ImgPath = "assets/null-car.png",
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
            if (vehicle.VehicleId == 0)
            {
                // Add new vehicle
                _context.Vehicles.Add(vehicle);
            }
            else
            {
                // Update existing vehicle
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
