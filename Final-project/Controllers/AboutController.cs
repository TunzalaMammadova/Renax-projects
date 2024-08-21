using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class AboutController : Controller
	{
        private readonly IAboutService _about;

        public AboutController(IAboutService about)
        {
            _about = about;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<About> abouts = await _about.GetAllAsync();

            HomeVM model = new()
            {
                Abouts = abouts
            };

            return View(model);
        }
    }
}

