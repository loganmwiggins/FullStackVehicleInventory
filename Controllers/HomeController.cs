using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VehicleInventoryProj.Models;

namespace VehicleInventoryProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; // Provide access to model  

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
    //public IActionResult Index()
    //{
    //    try
    //    {
    //        // Example: If you want to fetch some data from the database in the future:
    //        // var someData = _context.SomeTable.ToList();

    //        return View();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError("Error occurred while loading the home page: {Error}", ex.Message);
    //        return View("Error"); // Return a custom error view if something goes wrong
        }
    

