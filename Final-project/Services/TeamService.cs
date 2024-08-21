using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Teams;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class TeamService : ITeamService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamService(AppDbContext context,
                           IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _context.Teams.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await _context.Teams.Where(m => !m.SoftDeleted).ToListAsync();

        }

        public async Task CreateAsync(TeamCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Teams.AddAsync(new Team { Image = fileName, Name = request.Name, Description = request.Description });

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Team team)
        {
            string path = Path.Combine(_env.WebRootPath, "assets/image", team.Image, team.Name, team.Description);

            path.DeleteFileFromToLocal();

            _context.Teams.Remove(team);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Team team, TeamEditVM editVM)
        {

            if (editVM.NewImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "assets/image", team.Image);

                oldPath.DeleteFileFromToLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + editVM.NewImage.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await editVM.NewImage.SaveFileToLocalAsync(newPath);

                team.Image = fileName;
            }

            team.Name = editVM.Name;
            team.Description = editVM.Description;

            await _context.SaveChangesAsync();
        }

        public async Task<List<TeamVM>> GetAllOrderByDescAsync()
        {
            List<Team> teams = await _context.Teams.OrderByDescending(m => m.Id).ToListAsync();

            return teams.Select(m => new TeamVM
            {
                Id = m.Id,
                Image = m.Image,
                Name = m.Name,
                Description = m.Description

            }).ToList();
        }

    }
}

