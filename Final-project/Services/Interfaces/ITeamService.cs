using System;
using Final_project.Models;
using Final_project.ViewModels.Teams;

namespace Final_project.Services.Interfaces
{
	public interface ITeamService
	{
        Task<Team> GetByIdAsync(int id);
        Task<List<Team>> GetAllAsync();
        Task<List<TeamVM>> GetAllOrderByDescAsync();
        Task CreateAsync(TeamCreateVM customer);
        Task DeleteAsync(Team team);
        Task EditAsync(Team team, TeamEditVM editVM);
    }
}

