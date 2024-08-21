using Final_project.Models;
using Final_project.ViewModels.Proccess;

namespace Final_project.Services.Interfaces
{
	public interface IProccessService
	{
        Task<Process> GetByIdAsync(int id);
        Task<List<Process>> GetAllAsync();
        Task<List<ProccessVM>> GetAllOrderByDescAsync();
        Task CreateAsync(ProcessCreateVM customer);
        Task DeleteAsync(Process process);
        Task EditAsync(Process process, ProccessEditVM editVM);
    }
}

