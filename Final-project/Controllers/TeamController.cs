using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class TeamController : Controller
	{
		private readonly ITeamService _teamService;

		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
        }


		public async Task<IActionResult> Index()
		{
			List<Team> team = await _teamService.GetAllAsync();

            HomeVM model = new()
            {
                Teams = team
            };

            return View(model);
        }

    }
}

