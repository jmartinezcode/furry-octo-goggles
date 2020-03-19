using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tmc.Models;
using tmc.Contracts;

namespace tmc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieServices _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieServices movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var popularMovies = await _movieService.GetPopularMovie();
            var topMovies = await _movieService.GetTopRatedMovie();
            var nowPlayingMovies = await _movieService.GetNowPlayingMovie();
            var upcomingMovies = await _movieService.GetUpcomingMovie();
            return View(popularMovies);
        }

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
