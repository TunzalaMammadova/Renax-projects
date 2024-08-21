using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Videos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class VideoController : Controller
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IVideoService _videoService;

        public VideoController(AppDbContext context,
                              IWebHostEnvironment env,
                              IVideoService videoService)
        {
            _context = context;
            _env = env;
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _videoService.GetAllOrderByDescAsync();
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
        public async Task<IActionResult> Create(VideoCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            if (!request.Video.CheckFileType("video/mp4"))
            {
                ModelState.AddModelError("Video", "File must be only video format");
                return View();
            }

            if (!request.Video.CheckFileSize(500))
            {
                ModelState.AddModelError("Video", "Video size must be max 500kb");
            }

            await _videoService.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var video = await _context.Videos.FirstOrDefaultAsync(m => m.Id == id);

            if (video is null) return NotFound();

            await _videoService.DeleteAsync(video);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var video = await _context.Videos.FirstOrDefaultAsync(m => m.Id == id);

            if (video is null) return NotFound();

            return View(new VideoEditVM { Video = video.BackgroundVideo });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, VideoEditVM request)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(m => m.Id == id);

            request.Video = video.BackgroundVideo;

            if (!ModelState.IsValid) return View(request);

            if (id is null) return BadRequest();

            if (video is null) return NotFound();

            if(request.NewVideo is not null)
            {
                if (!request.NewVideo.CheckFileType("video/mp4"))
                {
                    ModelState.AddModelError("NewVideo", "File must be only video format");
                    request.Video = video.BackgroundVideo;
                    return View(request);
                };

                if (!request.NewVideo.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewVideo", "NewVideo size must be max 500kb");
                    request.Video = video.BackgroundVideo;
                    return View(request);
                }
            }

            await _videoService.EditAsync(video, request);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var video = await _context.Videos.FirstOrDefaultAsync(m => m.Id == id);

            if (video is null) return NotFound();

            return View(new VideoDetailVM { Video = video.BackgroundVideo});
        }
    }
}


