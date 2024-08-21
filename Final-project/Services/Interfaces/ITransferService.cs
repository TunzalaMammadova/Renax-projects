using System;
using Final_project.Models;
using Final_project.ViewModels.Transfer;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_project.Services.Interfaces
{
	public interface ITransferService
	{
        Task<List<Service>> GetAllAsync();
        Task<List<TransferVM>> GetAllOrderByDescAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(TransferCreateVM transfer);
        Task<Service> GetWithProductAsync(int id);
        Task DeleteAsync(Service service);
        Task<Service> GetByIdAsync(int id);
        Task EditAsync(Service service, TransferEditVM transferEdit);
        Task<SelectList> GetAllBySelectAsync();
    }
}

