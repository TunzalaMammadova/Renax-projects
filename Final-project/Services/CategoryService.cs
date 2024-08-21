using System;
using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryService(AppDbContext context,
                               IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        

        public async Task CreateAsync(CategoryCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Categories.AddAsync(new Category { Name = request.Name, Image = fileName });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            string path = Path.Combine(_env.WebRootPath, "assets/image", category.Image, category.Name);
            
            path.DeleteFileFromToLocal();

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Category category, CategoryEditVM categoryEdit)
        {

            if (categoryEdit.NewImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "assets/image", category.Image);

                oldPath.DeleteFileFromToLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + categoryEdit.NewImage.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await categoryEdit.NewImage.SaveFileToLocalAsync(newPath);

                category.Image = fileName;
            }

            category.Name = categoryEdit.Name;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(m => m.Cars).Where(m => !m.SoftDeleted && m.Cars.Count != 0).ToListAsync();
        }

        public async Task<SelectList> GetAllBySelectAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }

        public async Task<List<CategoryVM>> GetAllOrderByDescAsync()
        {
            List<Category> categories = await _context.Categories.OrderByDescending(m => m.Id)
                                                                 .ToListAsync();
            return categories.Select(m => new CategoryVM { Id = m.Id, Name = m.Name,Image = m.Image }).ToList();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> GetWithProductAsync(int id)
        {
            return await _context.Categories.Where(m => m.Id == id)
                                            .Include(m => m.Cars)
                                            .FirstOrDefaultAsync();
        }
    }
}

