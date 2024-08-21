using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Brands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IBrandService _brandService;

        public BrandController(AppDbContext context,
                                IWebHostEnvironment env,
                                IBrandService brandService)
        {
            _context = context;
            _env = env;
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _brandService.GetAllOrderByDescAsync();
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
        public async Task<IActionResult> Create(BrandCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Images", "File must be only image format");
                return View();
            }

            if (!request.Image.CheckFileSize(500))
            {
                ModelState.AddModelError("Images", "Image size must be max 500kb");
            }

            await _brandService.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var brand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

            if (brand is null) return NotFound();

            await _brandService.DeleteAsync(brand);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var brand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

            if (brand is null) return NotFound();

            return View(new BrandEditVM { Image = brand.Image});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BrandEditVM request)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

            request.Image = brand.Image;

            if (!ModelState.IsValid) return View(request);

            if (id is null) return BadRequest();

            if (brand is null) return NotFound();

            if(request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "File must be only image format");
                    request.Image = brand.Image;
                    return View(request);
                };

                if (!request.NewImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewImage", "NewImage size must be max 500kb");
                    request.Image = brand.Image;
                    return View(request);
                }
            }

            await _brandService.EditAsync(brand, request);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var brand = await _context.Brands.FirstOrDefaultAsync(m => m.Id == id);

            if (brand is null) return NotFound();

            return View(new BrandDetailVM { Image = brand.Image });
        }
    }
}

