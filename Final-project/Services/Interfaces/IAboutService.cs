using System;
using Final_project.Models;
using Final_project.ViewModels.About;

namespace Final_project.Services.Interfaces
{
	public interface IAboutService
	{
        Task<About> GetByIdAsync(int id);
        Task<List<About>> GetAllAsync();
        Task<List<AboutVM>> GetAllOrderByDescAsync();
        Task CreateAsync(AboutCreateVM about);
        Task DeleteAsync(About about);
        Task EditAsync(About about, AboutEditVM editVM);
    }
}

