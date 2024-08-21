using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AboutController : Controller
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IAboutService _aboutService;

        public AboutController(AppDbContext context,
                               IWebHostEnvironment env,
                               IAboutService aboutService)
        {
            _context = context;
            _env = env;
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _aboutService.GetAllOrderByDescAsync();
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
        public async Task<IActionResult> Create(AboutCreateVM request)
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

            await _aboutService.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            if (about is null) return NotFound();

            await _aboutService.DeleteAsync(about);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            if (about is null) return NotFound();

            return View(new AboutEditVM { Image = about.Image, SubTitle = about.SubTitle,Title = about.Title, Description = about.Description });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AboutEditVM request)
        {
            var about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            request.Image = about.Image;

            if (!ModelState.IsValid) return View(request);

            if (id is null) return BadRequest();

            if (about is null) return NotFound();

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "File must be only image format");
                    request.Image = about.Image;
                    return View(request);
                };

                if (!request.NewImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewImage", "NewImage size must be max 500kb");
                    request.Image = about.Image;
                    return View(request);
                }
            }

            await _aboutService.EditAsync(about, request);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            if (about is null) return NotFound();

            return View(new AboutDetailVM { Image = about.Image, SubTitle = about.SubTitle,Title = about.Title, Description = about.Description });
        }
    }
}



