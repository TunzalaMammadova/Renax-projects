using System;
using Final_project.Helpers;
using Final_project.Helpers.Enum;
using Final_project.Helpers.Extensions;
using Final_project.Helpers.Request;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;


        public CarController(ICarService carService,
                             ICategoryService categoryService,
                             IWebHostEnvironment env)
        {
            _carService = carService;
            _categoryService = categoryService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var paginateDatas = await _carService.GetAllPaginateAsync(page);
            var mappedDatas = _carService.GetMappedDatas(paginateDatas);

            int pageCount = await GetPageCountAsync(4);
            Paginate<CarVM> model = new(mappedDatas, page, pageCount);

            return View(model);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int count = await _carService.GetCountAsync();
            return (int)Math.Ceiling((decimal)count / take);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car is null) return NotFound();

            List<CarImageVM> CarImages = new();

            foreach (var item in car.CarImages)
            {
                CarImages.Add(new CarImageVM
                {
                    Image = item.Image,
                    IsMain = item.IsMain
                });
            }

            CarDetailVM model = new()
            {
                Name = car.Name,
                Description = car.Description,
                Price = car.Price,
                Category = car.Category.Name,
                Age = car.Age,
                AirCondition = car.AirCondition,
                Door = car.Door,
                Luggage = car.Luggage,
                Passenger = car.Passenger,
                Transmission = car.Transmission,
                Images = CarImages
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCarImage(DeleteCarImageRequest request)
        {

            await _carService.DeleteCarImageAsync(request);

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car is null) return NotFound();

            foreach (var item in car.CarImages)
            {
                string path = Path.Combine(_env.WebRootPath, "assets/image", item.Image);
                path.DeleteFileFromToLocal();
            }

            await _carService.DeleteAsync(car);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.categories = await _categoryService.GetAllBySelectAsync();

            if (id is null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            if (car is null) return NotFound();

            CarEditVM response = new()
            {
                Name = car.Name,
                Description = car.Description,
                Price = car.Price,
                CategoryId = car.CategoryId,
                Age = car.Age,
                AirCondition = car.AirCondition,
                Door = car.Door,
                Luggage = car.Luggage,
                Passenger = car.Passenger,
                Transmission = car.Transmission,
                ExistImages = car.CarImages.Select(m => new CarEditImageVM
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    Image = m.Image,
                    IsMain = m.IsMain
                }).ToList()
            };

            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CarEditVM request)
        {
            ViewBag.categories = await _categoryService.GetAllBySelectAsync();

            if (id is null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)id);

            request.ExistImages = car.CarImages.Select(m => new CarEditImageVM { Image = m.Image }).ToList();
            if (!ModelState.IsValid) return View(request);

            if (car is null) return NotFound();

            List<CarImage> images = car.CarImages.ToList();

            if (request.NewImages is not null)
            {
                foreach (var item in request.NewImages)
                {
                    if (!item.CheckFileSize(500))
                    {
                        request.ExistImages = car.CarImages.Select(m => new CarEditImageVM
                        {
                            Id = m.Id,
                            CarId = m.CarId,
                            Image = m.Image,
                            IsMain = m.IsMain
                        }).ToList();

                        ModelState.AddModelError("NewImages", "Image size must be max 500kb");
                        return View(request);
                    }

                    if (!item.CheckFileType("image/"))
                    {
                        request.ExistImages = car.CarImages.Select(m => new CarEditImageVM
                        {
                            Id = m.Id,
                            CarId = m.CarId,
                            Image = m.Image,
                            IsMain = m.IsMain
                        }).ToList();

                        ModelState.AddModelError("NewImages", "File must be only image format");
                        return View(request);
                    }
                }
            }

            await _carService.EditAsync(car, request);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _categoryService.GetAllBySelectAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarCreateVM request)
        {
            ViewBag.categories = await _categoryService.GetAllBySelectAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var item in request.Image)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", "File must be only image format");
                    return View();
                }

                if (!item.CheckFileSize(800))
                {
                    ModelState.AddModelError("Images", "Image size must be max 800kb");
                }

            }

            List<CarImage> images = new();

            foreach (var item in request.Image)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await item.SaveFileToLocalAsync(path);

                images.Add(new CarImage
                {
                    Image = fileName
                });
            }

            images.FirstOrDefault().IsMain = true;

            Car car = new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                CarImages = images,
                Age = request.Age,
                AirCondition = request.AirCondition,
                Door = request.Door,
                Luggage = request.Luggage,
                Passenger = request.Passenger,
                Transmission = request.Transmission,
            };

            await _carService.CreateAsync(car);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeMainImage(int? id, int? CarId)
        {
            if (id is null || CarId is null) return BadRequest();

            Car car = await _carService.GetByIdAsync((int)CarId);

            if (car is null) NotFound();

            await _carService.ChangeMainImage(car, (int)id);

            return Ok();
        }
    }
}

