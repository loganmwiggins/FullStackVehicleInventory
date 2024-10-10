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

        [HttpGet("/home")]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("/movies")]
        //public IActionResult AllMovies()
        //{
        //    List<Movie> allMovies = _context.Movies
        //        .Include(m => m.Ratings)
        //        .ToList();

        //    return View(allMovies);
        //}

        //[HttpGet("/movies/{movie_id}")]
        //public IActionResult MovieDetails(int movie_id)
        //{
        //    var movie = _context.Movies.Where(m => m.MovieId == movie_id);

        //    return View(movie);
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
