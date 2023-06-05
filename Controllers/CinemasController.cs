using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAll();
            return View(cinemas);
        }

        //Cinema/Details
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetail = await _service.GetById(id);
            if (cinemaDetail == null) return View("NotFount");
            return View(cinemaDetail);
        }

        // Cinema/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
         {
            if (!ModelState.IsValid) return View(cinema);
            
            await _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }
    }
}
