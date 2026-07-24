using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        //private readonly int x;


        public HomeController(ILogger<HomeController> logger,IMovieService movieService)//method(int x, IMovieService movieService)
        {
            _logger = logger;
            _movieService = new MovieService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            //_movieService=new MovieService(); 
            //ViewBag.Title = "Movieshop home page title";
            //ViewBag.Description = new List<string>() { "abc", "def" };
            //ViewData["title"] = "Movie shop home page Title";
            //var movieService = new MovieService();//var movieService = new MovieServiceTest
            
            var movies=_movieService.Get30HighestGrossingMovies();


            return View(movies);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
