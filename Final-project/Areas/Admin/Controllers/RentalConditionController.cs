using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.RentalConditions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class RentalConditionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IRentalConditionService _rental;
        private readonly ICarService _carService;


        public RentalConditionController(AppDbContext context,
                                         IRentalConditionService rental,
                                         ICarService carService)
        {
            _context = context;
            _rental = rental;
            _carService = carService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _rental.GetAllOrderByDescAsync();
            return View(datas);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.cars = await _carService.GetAllBySelectAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalConditionCreateVM request)
        {
            ViewBag.cars = await _carService.GetAllBySelectAsync();

            if (!ModelState.IsValid) return View();

            await _rental.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var rental = await _rental.GetByIdAsync((int)id);

            if (rental is null) return NotFound();

            await _rental.DeleteAsync(rental);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.cars = await _carService.GetAllBySelectAsync();

            if (id is null) return BadRequest();

            var rental = await _rental.GetByIdAsync((int)id);

            if (rental is null) return NotFound();

            return View(new RentalConditionEditVM
            {

                Title = rental.Title,
                Description = rental.Description,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, RentalConditionEditVM editVM)
        {
            ViewBag.cars = await _carService.GetAllBySelectAsync();

            if (!ModelState.IsValid) return View(editVM);

            if (id is null) return BadRequest();

            var rental = await _rental.GetByIdAsync((int)id);

            if (rental is null) return NotFound();

            await _rental.EditAsync(rental, editVM);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var rental = await _rental.GetByIdAsync((int)id);

            if (rental is null) return NotFound();

            return View(new RentalConditionDetailVM
            {
                Title = rental.Title,
                Description = rental.Description,
                Car = rental.Car.Name
            });
        }
    }
}

