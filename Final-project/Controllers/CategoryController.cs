using System;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class CategoryController : Controller
	{
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Category data = await _category.GetByIdAsync((int)id);

            if (data is null) return NotFound();

            return View(data);
        }
    }
}

