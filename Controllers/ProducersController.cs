using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service ;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAll();
            return View(producers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetail = await _service.GetById(id);
            if (ProducerDetail==null) return View("NotFound");
            return View(ProducerDetail);
        }
    }
}
