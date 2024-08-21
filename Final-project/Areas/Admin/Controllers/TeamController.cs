using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ITeamService _teamService;

        public TeamController(AppDbContext context,
                              IWebHostEnvironment env,
                              ITeamService teamService)
        {
            _context = context;
            _env = env;
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _teamService.GetAllOrderByDescAsync();
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
        public async Task<IActionResult> Create(TeamCreateVM request)
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

            await _teamService.CreateAsync(request);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (team is null) return NotFound();

            await _teamService.DeleteAsync(team);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (team is null) return NotFound();

            return View(new TeamEditVM { Image = team.Image, Name = team.Name , Description = team.Description });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, TeamEditVM request)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            request.Image = team.Image;

            if (!ModelState.IsValid) return View(request);

            if (id is null) return BadRequest();

            if (team is null) return NotFound();

            if(request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "File must be only image format");
                    request.Image = team.Image;
                    return View(request);
                };

                if (!request.NewImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("NewImage", "NewImage size must be max 500kb");
                    request.Image = team.Image;
                    return View(request);
                }
            }


            await _teamService.EditAsync(team,request);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

            if (team is null) return NotFound();

            return View(new TeamDetailVM { Image = team.Image, Name = team.Name , Description = team.Description });
        }
    }
}

