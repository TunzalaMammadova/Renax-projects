using System;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Final_project.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class CarController: Controller
	{
        private readonly ICarService _carService;
        private readonly ICategoryService _categoryService;

        public CarController(ICarService car, ICategoryService categoryService)
        {
            _carService = car;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Car> car = await _carService.GetAllAsync();
            List<Category> categories = await _categoryService.GetAllAsync();


            HomeVM model = new()
            {
                Cars = car,
                Categories = categories
            };

            return View(model);
        }


        public async Task<IActionResult> Search(string searchText)
        {
            IEnumerable<Car> cars = await _carService.GetAllAsync();

            if(searchText is not null)
            {
                cars = cars.Where(m => m.Name.ToLower().Contains(searchText.ToLower().Trim())).ToList();
            }
         
            List<CarVM> carmodel = cars.Select(m => new CarVM
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Image = m.CarImages.FirstOrDefault(m => m.IsMain).Image,
                Category = m.Category.Name,
                CategoryId = m.CategoryId,
                Age = m.Age,
                AirCondition = m.AirCondition,
                Door = m.Door,
                Luggage = m.Luggage,
                Passenger = m.Passenger,
                Transmission = m.Transmission,

            }).ToList();

            HomeVM model = new()
            {
                Cars = cars.ToList()
             };

            return PartialView("_CarListPartialView", model);
        }

    }
}

