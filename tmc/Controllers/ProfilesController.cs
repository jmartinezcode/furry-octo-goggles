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

            var user = _context.Profiles.FirstOrDefault(p => p.UserId == userId);
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
        public async Task<IActionResult> RecommendMovie(int id)
        {
            var viewModel = new MovieViewModel();
            var recommendMovies = await GetRecommendedMovie(id);
            viewModel.RecommendedMovie = recommendMovies;
            return View(viewModel);
        }
        public async Task<RecommendedMovie> GetRecommendedMovie(int id)
        {
            var client = new HttpClient();
            var base_url = "https://api.themoviedb.org/3/movie/";
            var middle_url = "/recommendations?api_key=";
            var end_url = "&language=en-US&page=1";
            var response = await client.GetAsync(base_url + id + middle_url + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<RecommendedMovie>(json);
            }
            return null;
        }
        //public IActionResult AddToWatchlist()
        //{
        //    return RedirectToAction(nameof(Details));
        //}

        [HttpPost]
        public IActionResult AddToWatchlist(int id)
        {
            var viewModel = new MovieViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _context.Profiles.FirstOrDefault(p => p.UserId == userId);
            if (user is null)
            {
                return RedirectToAction(nameof(Create));
            }
            viewModel.Profile = user;
            var watchlist = _context.Watchlists.FirstOrDefault(w => w.ProfileId == viewModel.Profile.Id);
            if (watchlist is null)
            {
                watchlist = new Watchlist();
            }
            viewModel.Watchlist = watchlist;
            viewModel.MovieWatchlist = new MovieWatchlist();
            viewModel.MovieWatchlist.MovieId = id;
            viewModel.MovieWatchlist.WatchlistId = viewModel.Watchlist.Id;

            _context.Add(viewModel);
            _context.SaveChanges();

            return View(viewModel);
        }

        public IActionResult RateMovie(int id, int score)
        {
            var viewModel = new MovieViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _context.Profiles.FirstOrDefault(p => p.UserId == userId);
            if (user is null)
            {
                return RedirectToAction(nameof(Create));
            }
            viewModel.Profile = user;
            var rating = _context.MovieRatings.FirstOrDefault(r => r.ProfileId == viewModel.Profile.Id);

            viewModel.MovieRating = rating;
            viewModel.MovieRating.MovieId = id;
            viewModel.MovieRating.Rating = score;
            viewModel.MovieRating.RatingDate = DateTime.Now;

            _context.Add(viewModel);
            _context.SaveChanges();

            return View();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var viewModel = new MovieViewModel();
            var movie = await GetMovieDetails(id);
            viewModel.Movie = movie;
            viewModel.RecommendedMovie = await GetRecommendedMovie(id);
            return View(viewModel);
        }

        public async Task<Movie> GetMovieDetails(int id)
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                var newProfile = new Profile();
                newProfile.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                newProfile.FullName = profile.FullName;
                newProfile.ProfileName = profile.ProfileName;
                _context.Add(newProfile);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
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