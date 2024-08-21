using Final_project.Helpers;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Final_project.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    public class CarListingController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICategoryService _categoryService;

        public CarListingController(ICarService car, ICategoryService categoryService)
        {
            _carService = car;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string sort, int page = 1)
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            var paginateDatas = await _carService.GetAllPaginateAsync(page);
            var mappedDatas = _carService.GetMappedDatas(paginateDatas);

            int pageCount = await GetPageCountAsync(4);
            Paginate<CarVM> model = new(mappedDatas, page, pageCount);

            if (sort is not null)
            {
              return await Sorting(sort, paginateDatas, page);
            }

            HomeVM carModel = new()
            {
                PaginateCar = model,
                Categories = categories
            };

            return View(carModel);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int count = await _carService.GetCountAsync();

            return (int)Math.Ceiling((decimal)count / take);
        }

        private async Task<IActionResult> Sorting(string sort, List<Car> paginateDatas,int page)
        {

            switch (sort)
            {
                case "A-Z sorting":
                    paginateDatas = paginateDatas.OrderBy(m => m.Name).ToList();
                    break;
                case "Z-A sorting":
                    paginateDatas = paginateDatas.OrderByDescending(m => m.Name).ToList();
                    break;
                case "Latest":
                    paginateDatas = paginateDatas.OrderBy(m => m.Id).ToList();
                    break;
                case "Price: Low to High":
                    paginateDatas = paginateDatas.OrderBy(m => m.Price).ToList();
                    break;
                case "Price: High to Low":
                    paginateDatas = paginateDatas.OrderByDescending(m => m.Price).ToList();
                    break;
                default:
                    break;
            }

            var mappedDatas = _carService.GetMappedDatas(paginateDatas);

            int pageCount = await GetPageCountAsync(4);
            Paginate<CarVM> model = new(mappedDatas, page, pageCount);

            HomeVM carModel = new()
            {
                PaginateCar = model,
            };

            return PartialView("_CarPartialView", carModel);
        }

    }

}