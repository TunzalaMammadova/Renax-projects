using System;
using Final_project.Models;
using Final_project.Services;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class ProccessController : Controller
    {
        private readonly IProccessService _proccess;

        public ProccessController(IProccessService proccess)
        {
            _proccess = proccess;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Process data = await _proccess.GetByIdAsync((int)id);

            if (data is null) return NotFound();

            return View(data);
        }
    }
}
	


