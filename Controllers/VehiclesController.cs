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
    }
}
