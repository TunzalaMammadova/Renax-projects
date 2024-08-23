using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProccessService _proccessService;
        private readonly IVideoInfoService _videoInfo;
        private readonly IBrandService _brandService;
        private readonly IAboutService _aboutService;
        private readonly ICategoryService _categoryService;
        private readonly IVideoService _videoService;
        private readonly ITransferService _transferService;
        private readonly ICarService _carService;
        private readonly ITeamService _teamService;
        private readonly ISubscriberService _subscriberService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IProccessService proccessService,
                              IVideoInfoService videoInfo,
                              IBrandService brandService,
                              IAboutService aboutService,
                              ICategoryService categoryService,
                              IVideoService videoService,
                              ITransferService transferService,
                              ICarService car,
                              ITeamService team,
                              ISubscriberService subscriberService,
                              UserManager<AppUser> userManager)


        {
            _proccessService = proccessService;
            _videoInfo = videoInfo;
            _brandService = brandService;
            _aboutService = aboutService;
            _categoryService = categoryService;
            _videoService = videoService;
            _transferService = transferService;
            _carService = car;
            _teamService = team;
            _subscriberService = subscriberService;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            List<Process> processes = await _proccessService.GetAllAsync();
            List<VideoInfo> videoInfo = await _videoInfo.GetAllAsync();
            List<Brand> brand = await _brandService.GetAllAsync();
            List<About> abouts = await _aboutService.GetAllAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            List<Video> video = await _videoService.GetAllAsync();
            List<Car> car = await _carService.GetAllAsync();
            List<Service> services = await _transferService.GetAllAsync();
            List<Team> teams= await _teamService.GetAllAsync();

            HomeVM model = new()
            {
                Proccesses = processes,
                VideoInfos = videoInfo,
                Brands = brand,
                Categories = categories,
                Videos = video,
                Abouts = abouts,
                Cars = car,
                Services = services,
                Teams = teams,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string subscriberEmail)
        {
            await _subscriberService.Create(new Subscriber { SubscriberEmail = subscriberEmail });
            return Ok();
        }

        [Route("/StatusCodeError/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                ViewBag.ErrorMessage = "Sorry We Can't Find That Page!";
            }

            return View("Error");

        }
    }
}
