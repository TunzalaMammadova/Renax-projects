using System;
using Final_project.Models;

namespace Final_project.Services.Interfaces
{
	public interface IAccountService
	{
        Task<List<AppUser>> GetAll();
        Task<IList<string>> GetRoles(AppUser user);
    }
}

