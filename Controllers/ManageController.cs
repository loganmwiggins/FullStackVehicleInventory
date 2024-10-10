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


        // CRUD Functionality
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
