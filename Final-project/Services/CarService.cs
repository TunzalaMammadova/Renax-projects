using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Helpers.Request;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class CarService : ICarService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public CarService(AppDbContext context,
                              IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.Include(m => m.Category)
                                      .Include(m => m.CarImages)
                                      .ToListAsync();
        }

        public async Task<List<Car>> GetAllWithImagesAsync()
        {
            return await _context.Cars.Include(m => m.CarImages).ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.Where(m => !m.SoftDeleted)
                                      .Include(m => m.Category)
                                      .Include(m => m.CarImages)
                                      .Include(m => m.RentalConditions)
                                      .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Car>> GetAllPaginateAsync(int page, int take = 4)
        {
            return await _context.Cars.Where(m => !m.SoftDeleted)
                                      .Include(m => m.Category)
                                      .Include(m => m.CarImages)
                                      .Skip((page - 1) * take)
                                      .Take(take)
                                      .ToListAsync();
        }


        public List<CarVM> GetMappedDatas(List<Car> cars)
        {
            return cars.Select(m => new CarVM
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Image = m.CarImages.FirstOrDefault(m => m.IsMain).Image,
                Category = m.Category.Name,
                Age = m.Age,
                AirCondition = m.AirCondition,
                Door = m.Door,
                Luggage = m.Luggage,
                Passenger = m.Passenger,
                Transmission = m.Transmission,
                
        }).ToList();
        }


        public async Task<int> GetCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task DeleteCarImageAsync(DeleteCarImageRequest request)
        {
            var car = await _context.Cars.Where(m => m.Id == request.CarId)
                                         .Include(m => m.CarImages)
                                         .FirstOrDefaultAsync();

            var carImage = car.CarImages.FirstOrDefault(m => m.Id == request.ImageId);

            string path = Path.Combine(_env.WebRootPath, "assets/image", carImage.Image);

            path.DeleteFileFromToLocal();

            car.CarImages.Remove(carImage);

            await _context.SaveChangesAsync();
        }


        public async Task EditAsync(Car car, CarEditVM editVM)
        {
            List<CarImage> images = car.CarImages.ToList();

            if (editVM.NewImages is not null)
            {
                foreach (var item in editVM.NewImages)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                    string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                    await item.SaveFileToLocalAsync(newPath);
                    car.CarImages.Add(new CarImage { Image = fileName });

                    CarImage image = new()
                    {
                       Image = fileName
                    };

                    images.Add(image);

                }
            }

            car.CarImages = images;
            car.Name = editVM.Name;
            car.Description = editVM.Description;
            car.CategoryId = editVM.CategoryId;
            car.Price = editVM.Price;
            car.Age = editVM.Age;
            car.AirCondition = editVM.AirCondition;
            car.Door = editVM.Door;
            car.Luggage = editVM.Luggage;
            car.Passenger = editVM.Passenger;
            car.Transmission = editVM.Transmission;
            await _context.SaveChangesAsync();

        }

        public async Task CreateAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<SelectList> GetAllBySelectAsync()
        {
            var cars = await _context.Cars.ToListAsync();
            return new SelectList(cars, "Id", "Name");
        }

        public async Task ChangeMainImage(Car car, int imageId)
        {
            var images = car.CarImages.Where(m => m.IsMain == true);
            foreach (var image in images)
            {
                image.IsMain = false;
            }

            car.CarImages.FirstOrDefault(m => m.Id == imageId).IsMain = true;
            await _context.SaveChangesAsync();
        }

    }
}


