using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Transfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class TransferController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITransferService _transferService;
        private readonly IWebHostEnvironment _env;

        public TransferController(AppDbContext context,
                                  ITransferService transferService,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _transferService = transferService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _transferService.GetAllOrderByDescAsync();
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
        public async Task<ActionResult> Create(TransferCreateVM request)
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

            bool existTransfer = await _transferService.ExistAsync(request.Name);

            if (existTransfer)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }

            await _transferService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Service service = await _transferService.GetWithProductAsync((int)id);

            if (service is null) return NotFound();

            await _transferService.DeleteAsync(service);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Service service = await _transferService.GetByIdAsync((int)id);

            if (service is null) return NotFound();

            return View(new TransferEditVM { Id = service.Id, Name = service.Name, Image = service.Image, Description = service.Description});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, TransferEditVM request)
        {
            var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

            request.Image = service.Image;

            if (!ModelState.IsValid) return View(request);

            if (id is null) return BadRequest();

            if (service is null) return NotFound();

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "File must be only image format");
                    request.Image = service.Image;
                    request.Description = service.Description;
                    return View(request);
                };

                if (!request.NewImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewImage", "NewImage size must be max 500kb");
                    request.Image = service.Image;
                    return View(request);
                }
            }

            await _transferService.EditAsync(service, request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

            if (service is null) return NotFound();

            return View(new TransferDetailVM
            {
                Image = service.Image,
                Name = service.Name,
                Description = service.Description
            });

        }
    }
}

