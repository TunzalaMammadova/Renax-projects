using System;
using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Brands;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class BrandService : IBrandService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandService(AppDbContext context,
                           IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brands.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.Where(m => !m.SoftDeleted).ToListAsync();

        }

        public async Task CreateAsync(BrandCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Brands.AddAsync(new Brand { Image = fileName});

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Brand brand)
        {
            string path = Path.Combine(_env.WebRootPath, "assets/image", brand.Image);

            path.DeleteFileFromToLocal();

            _context.Brands.Remove(brand);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Brand brand, BrandEditVM editVM)
        {

            if (editVM.NewImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "assets/image", brand.Image);

                oldPath.DeleteFileFromToLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + editVM.NewImage.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await editVM.NewImage.SaveFileToLocalAsync(newPath);

                brand.Image = fileName;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<BrandVM>> GetAllOrderByDescAsync()
        {
            List<Brand> brands = await _context.Brands.OrderByDescending(m => m.Id).ToListAsync();

            return brands.Select(m => new BrandVM
            {

                Id = m.Id,
                Image = m.Image,

            }).ToList();
        }

    }
}

