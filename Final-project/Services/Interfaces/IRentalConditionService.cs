using System;
using Final_project.Models;
using Final_project.ViewModels.RentalConditions;

namespace Final_project.Services.Interfaces
{
	public interface IRentalConditionService
	{
        Task<RentalCondition> GetByIdAsync(int id);
        Task<List<RentalCondition>> GetAllAsync();
        Task CreateAsync(RentalConditionCreateVM rental);
        Task DeleteAsync(RentalCondition rental);
        Task EditAsync(RentalCondition rental, RentalConditionEditVM editVM);
        Task<List<RentalConditionVM>> GetAllOrderByDescAsync();
    }
}

