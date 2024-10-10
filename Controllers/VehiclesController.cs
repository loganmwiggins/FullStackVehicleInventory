using Microsoft.AspNetCore.Mvc;
using VehicleInventoryProj.Models;

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
        public IActionResult Index()
        {
            List<Vehicle> allVehicles = _context.Vehicles.ToList();

            return View(allVehicles);
        }

        // Action to handle GET requests to /vehicles/{vehicle_id}
        // Retrieves details of a specific vehicle based on its vehicle_id
        [HttpGet("/vehicles/{vehicle_id}")]
        public IActionResult VehicleDetails(int vehicle_id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(m => m.VehicleId == vehicle_id);

            if (vehicle == null) return NotFound();

            return View(vehicle);
        }
    }
}