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


        [HttpGet("/vehicles")]
        public IActionResult Index()
        {
            List<Vehicle> allVehicles = _context.Vehicles.ToList();

            return View(allVehicles);
        }

        [HttpGet("/vehicles/{vehicle_id}")]
        public IActionResult VehicleDetail(int vehicle_id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(m => m.VehicleId == vehicle_id);

            if (vehicle == null) return NotFound();

            return View(vehicle);
        }


    }
}
