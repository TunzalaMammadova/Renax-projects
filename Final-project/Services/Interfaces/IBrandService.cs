using System;
using Final_project.Models;
using Final_project.ViewModels.Brands;

namespace Final_project.Services.Interfaces
{
	public interface IBrandService
	{
        Task<Brand> GetByIdAsync(int id);
        Task<List<Brand>> GetAllAsync();
        Task<List<BrandVM>> GetAllOrderByDescAsync();
        Task CreateAsync(BrandCreateVM request);
        Task DeleteAsync(Brand brand);
        Task EditAsync(Brand brand, BrandEditVM editVM);
    }
}

