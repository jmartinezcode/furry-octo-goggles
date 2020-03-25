using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmc.Models;
using tmc.Data;
using tmc.Contracts;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json;

namespace tmc.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMovieServices _movieService;        
        
        public ProfilesController(ApplicationDbContext context, IMovieServices services)
        {
            _context = context;
            _movieService = services;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var viewModel = new MovieViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _context.SiteUsers.FirstOrDefault(u => u.UserId == userId);
            if (user is null)
            {
                return RedirectToAction(nameof(Create));
            }
            viewModel.Profile = user;

            var popularMovies = await _movieService.GetPopularMovie();
            var topMovies = await _movieService.GetTopRatedMovie();
            var nowPlayingMovies = await _movieService.GetNowPlayingMovie();
            var upcomingMovies = await _movieService.GetUpcomingMovie();

            viewModel.PopularMovie = popularMovies;
            viewModel.TopRatedMovie = topMovies;
            viewModel.NowPlayingMovie = nowPlayingMovies;
            viewModel.UpcomingMovie = upcomingMovies;

            return View(viewModel);
        }
        public async Task<IActionResult> Search(string query)
        {
            var viewModel = new MovieViewModel();
            var searchMovies = await SearchMovie(query);
            viewModel.SearchMovie = searchMovies;
            return View(viewModel);
        }
        public async Task<SearchMovie> SearchMovie(string query)
        {
            var client = new HttpClient();
            var base_search_url = "https://api.themoviedb.org/3/search/movie?api_key=";
            var end_search_url = "&language=en-US&page=1&include_adult=false&query=";
            var response = await client.GetAsync(base_search_url + API_KEYS.TheMovieDbAPI + end_search_url + query);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<SearchMovie>(json);
            }
            return null;
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var viewModel = new MovieViewModel();
            var movie = await GetMovieDetails(id);
            viewModel.Movie = movie;
            return View(viewModel);
        }

        public async Task<Movie> GetMovieDetails(int? id)
        {
            var client = new HttpClient();
            var base_details_url = "https://api.themoviedb.org/3/movie/";
            var response = await client.GetAsync(base_details_url + id + "?api_key=" + API_KEYS.TheMovieDbAPI);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Movie>(json);
            }
            return null;
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}