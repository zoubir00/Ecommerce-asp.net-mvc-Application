using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
