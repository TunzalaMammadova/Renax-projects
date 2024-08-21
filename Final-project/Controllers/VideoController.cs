using System;
using System.Diagnostics;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class VideoController : Controller
	{
        private readonly IVideoService _video;

        public VideoController(IVideoService video)
        {
            _video = video;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Video data = await _video.GetByIdAsync((int)id);

            if (data is null) return NotFound();

            return View(data);
        }
    }
}

