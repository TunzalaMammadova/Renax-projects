using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.ServiceCondition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ServiceConditionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IServiceConditionService _service;
        private readonly ITransferService _transfer;


        public ServiceConditionController(AppDbContext context,
                                          IServiceConditionService service,
                                          ITransferService transfer)
        {
            _context = context;
            _service = service;
            _transfer = transfer;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _service.GetAllOrderByDescAsync();
            return View(datas);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceConditionCreateVM request)
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();

            if (!ModelState.IsValid) return View();

            await _service.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var service = await _service.GetByIdAsync((int)id);

            if (service is null) return NotFound();

            await _service.DeleteAsync(service);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();

            if (id is null) return BadRequest();

            var service = await _service.GetByIdAsync((int)id);

            if (service is null) return NotFound();

            return View(new ServiceConditionEditVM
            {

                Title = service.Title,
                Description = service.Description,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ServiceConditionEditVM editVM)
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();

            if (!ModelState.IsValid) return View(editVM);

            if (id is null) return BadRequest();

            var service = await _service.GetByIdAsync((int)id);

            if (service is null) return NotFound();

            await _service.EditAsync(service, editVM);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var service = await _service.GetByIdAsync((int)id);

            if (service is null) return NotFound();

            return View(new ServiceConditionDetailVM
            {
                Title = service.Title,
                Description = service.Description,
                Service = service.Service.Name

            });
        }
    }
}


