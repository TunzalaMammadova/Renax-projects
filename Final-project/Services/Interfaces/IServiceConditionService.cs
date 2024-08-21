using System;
using Final_project.Models;
using Final_project.ViewModels.ServiceCondition;

namespace Final_project.Services.Interfaces
{
	public interface IServiceConditionService
	{
        Task<ServiceCondition> GetByIdAsync(int id);
        Task<List<ServiceCondition>> GetAllAsync();
        Task CreateAsync(ServiceConditionCreateVM service);
        Task DeleteAsync(ServiceCondition service);
        Task EditAsync(ServiceCondition service, ServiceConditionEditVM editVM);
        Task<List<ServiceConditionVM>> GetAllOrderByDescAsync();
    }
}

