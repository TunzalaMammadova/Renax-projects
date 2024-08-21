using System;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class CarDetailController : Controller
    {
        private readonly ICarService _carService;


        public CarDetailController(ICarService car)
        {
            _carService = car;
        }


        public async Task<IActionResult> Index(int? id)
        {
            Car car = await _carService.GetByIdAsync((int)id);

            HomeVM model = new()
            {
                Car = car,
            };

            return View(model);
        }
    }
}

