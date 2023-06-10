using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    [Authorize]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cinemas = await _service.GetAll();
            return View(cinemas);
        }

        [AllowAnonymous]
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

        //Cinema/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetail = await _service.GetById(id);
            if (cinemaDetail == null) return View("NotFount");
            return View(cinemaDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            if(id==cinema.Id) await _service.Updateasync(id,cinema);

            return View(cinema);
        }

        //Cinema/Delete

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetail = await _service.GetById(id);
            if (cinemaDetail == null) return View("NotFount");
            return View(cinemaDetail);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetail = await _service.GetById(id);
            if (cinemaDetail == null) return View("NotFount");
            await  _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
