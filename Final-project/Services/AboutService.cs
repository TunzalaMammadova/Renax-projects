using System;
using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.About;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class AboutService : IAboutService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutService(AppDbContext context,
                           IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _context.Abouts.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<About>> GetAllAsync()
        {
            return await _context.Abouts.Where(m => !m.SoftDeleted).ToListAsync();

        }

        public async Task CreateAsync(AboutCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Abouts.AddAsync(new About { Image = fileName, SubTitle = request.SubTitle,Title = request.Title, Description = request.Description });

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(About about)
        {
            string path = Path.Combine(_env.WebRootPath, "assets/image", about.Image, about.SubTitle,about.Title,about.Description);

            path.DeleteFileFromToLocal();

            _context.Abouts.Remove(about);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(About about, AboutEditVM editVM)
        {

            if (editVM.NewImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "assets/image", about.Image);

                oldPath.DeleteFileFromToLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + editVM.NewImage.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await editVM.NewImage.SaveFileToLocalAsync(newPath);

                about.Image = fileName;
            }

            about.SubTitle = editVM.SubTitle;
            about.Title = editVM.Title;
            about.Description = editVM.Description;

            await _context.SaveChangesAsync();
        }

        public async Task<List<AboutVM>> GetAllOrderByDescAsync()
        {
            List<About> abouts = await _context.Abouts.OrderByDescending(m => m.Id).ToListAsync();

            return abouts.Select(m => new AboutVM
            {
                Id = m.Id,
                Image = m.Image,
                SubTitle = m.SubTitle,
                Title = m.Title,
                Description = m.Description

            }).ToList();
        }
    }
}

