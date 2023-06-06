using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAll(n=>n.Cinema);
            return View(movies);
        }

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
    }
}
