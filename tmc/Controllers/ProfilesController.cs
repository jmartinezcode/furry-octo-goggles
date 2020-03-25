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
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
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