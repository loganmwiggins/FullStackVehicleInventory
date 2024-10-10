using Microsoft.AspNetCore.Mvc;
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


        [HttpGet("/manage")]
        public IActionResult Index()
        {
            List<Vehicle> allVehicles = _context.Vehicles.ToList();

            return View(allVehicles);
        }
    }
}
