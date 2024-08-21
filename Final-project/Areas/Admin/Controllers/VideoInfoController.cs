using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.VideoInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas
{
	[Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class VideoInfoController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IVideoInfoService _videoInfo;

        public VideoInfoController(AppDbContext context,
                                   IVideoInfoService videoInfo)
        {
            _context = context;
            _videoInfo = videoInfo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _videoInfo.GetAllOrderByDescAsync();
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
        public async Task<IActionResult> Create(VideoInfoCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            await _videoInfo.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var videoInfo = await _videoInfo.GetByIdAsync((int)id);

            if (videoInfo is null) return NotFound();

            _videoInfo.DeleteAsync(videoInfo);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var videoInfo = await _videoInfo.GetByIdAsync((int)id);

            if (videoInfo is null) return NotFound();

            return View(new VideoInfoEditVM
            {
                Title = videoInfo.Title,
                SubTitle = videoInfo.SubTitle,
                Name = videoInfo.Name,
                Price = videoInfo.Price
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, VideoInfoEditVM editVM)
        {
            if (!ModelState.IsValid) return View(editVM);

            if (id is null) return BadRequest();

            var videoInfo = await _videoInfo.GetByIdAsync((int)id);

            if (videoInfo is null) return NotFound();

            await _videoInfo.EditAsync(videoInfo, editVM);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var videoInfo = await _videoInfo.GetByIdAsync((int)id);

            if (videoInfo is null) return NotFound();

            return View(new VideoInfoDetailVM
            {
                Title = videoInfo.Title,
                SubTitle = videoInfo.SubTitle,
                Name = videoInfo.Name,
                Price = videoInfo.Price
            });
        }
    }
}

