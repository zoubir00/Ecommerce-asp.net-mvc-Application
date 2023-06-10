using EticketsWebApp.Data;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Controllers
{
    [Authorize]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service ;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAll();
            return View(producers);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetail = await _service.GetById(id);
            if (ProducerDetail==null) return View("NotFound");
            return View(ProducerDetail);
        }
        //Create 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("profilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            await _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }
        //Edit/Producers 
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _service.GetById(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,profilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if(id==producer.Id) await _service.Updateasync(id,producer);
            
            return View(producer);
        }

        //Edit/Producers 
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _service.GetById(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) return View("NotFound");

            await _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }



    }
}
