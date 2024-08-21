using System;
using Final_project.Models;
using Final_project.Services;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class VideoInfoController : Controller
	{
        private readonly IVideoInfoService _videoInfo;

        public VideoInfoController(IVideoInfoService videoInfo)
        {
            _videoInfo = videoInfo;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            VideoInfo data = await _videoInfo.GetByIdAsync((int)id);

            if (data is null) return NotFound();

            return View(data);
        }
    }
}

