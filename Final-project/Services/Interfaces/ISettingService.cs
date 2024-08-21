using System;
using Final_project.Models;
using Final_project.ViewModels.Settings;

namespace Final_project.Services.Interfaces
{
	public interface ISettingService
	{
        Task<Dictionary<int, Dictionary<string, string>>> GetAll();
        Task<Setting> GetById(int id);
        Task Create(Setting setting);
        Task Edit(int id, Setting setting);
        Task Delete(Setting setting);
    }
}

