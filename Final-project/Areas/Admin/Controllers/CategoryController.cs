using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context,
                                  ICategoryService categoryService,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _categoryService = categoryService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _categoryService.GetAllOrderByDescAsync();
            return View(data);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryCreateVM request)
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

            bool existCategory = await _categoryService.ExistAsync(request.Name);

            if (existCategory)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }

            await _categoryService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetWithProductAsync((int)id);

            if (category is null) return NotFound();

            await _categoryService.DeleteAsync(category);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            return View(new CategoryEditVM { Id = category.Id, Name = category.Name , Image = category.Image});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, CategoryEditVM request)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            request.Image = category.Image;

            if (!ModelState.IsValid) return View(request);

            if (id is null) return BadRequest();

            if (category is null) return NotFound();

            if(request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "File must be only image format");
                    request.Image = category.Image;
                    return View(request);
                };

                if (!request.NewImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewImage", "NewImage size must be max 500kb");
                    request.Image = category.Image;
                    return View(request);
                }
            }

            await _categoryService.EditAsync(category, request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _context.Categories.Include(m=>m.Cars).FirstOrDefaultAsync(m => m.Id == id);

            if (category is null) return NotFound();

            return View(new CategoryDetailVM
            {
                Image = category.Image,
                Name = category.Name,
                CarCount = category.Cars.Count
            });

        }
    }
}

