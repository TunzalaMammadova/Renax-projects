using Final_project.Helpers.Request;
using Final_project.Models;
using Final_project.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_project.Services.Interfaces
{
	public interface ICarService
	{
        Task<List<Car>> GetAllWithImagesAsync();
        Task<Car> GetByIdAsync(int id);
        Task<List<Car>> GetAllAsync();
        List<CarVM> GetMappedDatas(List<Car> cars);
        Task<List<Car>> GetAllPaginateAsync(int page, int take = 4);
        Task<int> GetCountAsync();
        Task CreateAsync(Car cars);
        Task DeleteAsync(Car cars);
        Task DeleteCarImageAsync(DeleteCarImageRequest request);
        Task EditAsync(Car car, CarEditVM editVM);
        Task<SelectList> GetAllBySelectAsync();
        Task ChangeMainImage(Car car, int id);
    }
}

