using System;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountService(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<List<AppUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IList<string>> GetRoles(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}


