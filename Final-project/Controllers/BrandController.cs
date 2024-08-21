using System;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class BrandController : Controller
	{
        private readonly IBrandService _brand;

        public BrandController(IBrandService brand)
        {
            _brand = brand;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Brand data = await _brand.GetByIdAsync((int)id);

            if (data is null) return NotFound();

            return View(data);
        }
    }
}

