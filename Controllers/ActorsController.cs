using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await _service.GetAll();
            return View(actors);
        }

        // Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("profilePictureURL,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var ActorDetail =await _service.GetById(id);
            if (ActorDetail == null) return View("Empty"); 
            return View(ActorDetail);
        }

    }
}
