using System;
using Final_project.Models;
using Final_project.ViewModels.ServiceDetails;

namespace Final_project.Services.Interfaces
{
	public interface IServiceDetailService
	{
        Task<ServiceDetail> GetByIdAsync(int id);
        Task<List<ServiceDetail>> GetAllAsync();
        Task CreateAsync(ServiceDetailCreateVM detail);
        Task DeleteAsync(ServiceDetail detail);
        Task EditAsync(ServiceDetail detail, ServiceDetailEditVM editVM);
        Task<List<ServiceDetailVM>> GetAllOrderByDescAsync();
    }
}

