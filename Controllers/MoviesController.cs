using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAll(n=>n.Cinema);
            return View(movies);
        }

        // Filter movies
        public async Task<IActionResult> Filter(string searchString)
        {
            var Allmovies = await _service.GetAll(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filterdResult = Allmovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterdResult);
            }
            return View("Index", Allmovies);
        }


        [AllowAnonymous]
        // Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieBYIdAsync(id);
            return View(movieDetail);
        }

        // Get: Movies/Create

        public async Task<IActionResult> Create()
        {
            var MovieDropdownData =await _service.GetNewMoviesDropdownsVlaues();

            ViewBag.actors = new SelectList(MovieDropdownData.Actors, "Id", "FullName");
            ViewBag.producers = new SelectList(MovieDropdownData.Producers, "Id", "FullName");
            ViewBag.cinemas = new SelectList(MovieDropdownData.Cinemas, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var MovieDropdownData = await _service.GetNewMoviesDropdownsVlaues();

                  ViewBag.actors = new SelectList(MovieDropdownData.Actors, "Id", "FullName");
                  ViewBag.producers = new SelectList(MovieDropdownData.Producers, "Id", "FullName");
                  ViewBag.cinemas = new SelectList(MovieDropdownData.Cinemas, "Id", "Name");
                  return View(movie);
            }
            await _service.CreateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
          
        }

        // Get: Movies/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieBYIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                CinemaId = movieDetails.CinemaId,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.Id).ToList()
                
            };

            var MovieDropdownData = await _service.GetNewMoviesDropdownsVlaues();

            ViewBag.actors = new SelectList(MovieDropdownData.Actors, "Id", "FullName");
            ViewBag.producers = new SelectList(MovieDropdownData.Producers, "Id", "FullName");
            ViewBag.cinemas = new SelectList(MovieDropdownData.Cinemas, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");


            if (!ModelState.IsValid)
            {
                var MovieDropdownData = await _service.GetNewMoviesDropdownsVlaues();

                ViewBag.actors = new SelectList(MovieDropdownData.Actors, "Id", "FullName");
                ViewBag.producers = new SelectList(MovieDropdownData.Producers, "Id", "FullName");
                ViewBag.cinemas = new SelectList(MovieDropdownData.Cinemas, "Id", "Name");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));

        }

    }
}
