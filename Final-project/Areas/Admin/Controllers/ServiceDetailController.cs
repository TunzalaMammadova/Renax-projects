using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.ServiceDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ServiceDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IServiceDetailService _detail;
        private readonly ITransferService _transfer;


        public ServiceDetailController(AppDbContext context,
                                          IServiceDetailService detail,
                                          ITransferService transfer)
        {
            _context = context;
            _detail = detail;
            _transfer = transfer;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _detail.GetAllOrderByDescAsync();
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
        public async Task<IActionResult> Create(ServiceDetailCreateVM request)
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();

            if (!ModelState.IsValid) return View();

            await _detail.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var detail = await _detail.GetByIdAsync((int)id);

            if (detail is null) return NotFound();

            await _detail.DeleteAsync(detail);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();

            if (id is null) return BadRequest();

            var detail = await _detail.GetByIdAsync((int)id);

            if (detail is null) return NotFound();

            return View(new ServiceDetailEditVM
            {

                Description = detail.Description,
                Options = detail.Options,
                OptionDescription = detail.OptionDescription,
                Booking = detail.Booking,
                BookingDescription = detail.BookingDescription,
                Luggage = detail.Luggage,
                LuggageDescription = detail.LuggageDescription,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ServiceDetailEditVM editVM)
        {
            ViewBag.services = await _transfer.GetAllBySelectAsync();

            if (!ModelState.IsValid) return View(editVM);

            if (id is null) return BadRequest();

            var detail = await _detail.GetByIdAsync((int)id);

            if (detail is null) return NotFound();

            await _detail.EditAsync(detail, editVM);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var detail = await _detail.GetByIdAsync((int)id);

            if (detail is null) return NotFound();

            return View(new ServiceDetailDetailVM
            {
                Description = detail.Description,
                Options = detail.Options,
                OptionDescription = detail.OptionDescription,
                Booking = detail.Booking,
                BookingDescription = detail.BookingDescription,
                Luggage = detail.Luggage,
                LuggageDescription = detail.LuggageDescription,
                Service = detail.Service.Name
            });
        }
    }
}


