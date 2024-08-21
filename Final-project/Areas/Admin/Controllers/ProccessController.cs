using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Proccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ProccessController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProccessService _proccessService;

        public ProccessController(AppDbContext context,
                                  IProccessService proccessService)
        {
            _context = context;
            _proccessService = proccessService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _proccessService.GetAllOrderByDescAsync();
            return View(datas);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            await _proccessService.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var setting = await _proccessService.GetByIdAsync((int)id);

            if (setting is null) return NotFound();

            _proccessService.DeleteAsync(setting);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)

        {
            if (id is null) return BadRequest();

            var proccess = await _proccessService.GetByIdAsync((int)id);

            if (proccess is null) return NotFound();

            return View(new ProccessEditVM
            {

                Title = proccess.Title,
                Description = proccess.Description,
                Number = proccess.Number,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ProccessEditVM editVM)
        {
            if (!ModelState.IsValid) return View(editVM);

            if (id is null) return BadRequest();

            var process = await _proccessService.GetByIdAsync((int)id);

            if (process is null) return NotFound();

            await _proccessService.EditAsync(process, editVM);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var process = await _proccessService.GetByIdAsync((int)id);

            if (process is null) return NotFound();

            return View(new ProccessDetailVM
            {
                Title = process.Title,
                Description = process.Description,
                Number = process.Number
                
            });
        }
    }
}

