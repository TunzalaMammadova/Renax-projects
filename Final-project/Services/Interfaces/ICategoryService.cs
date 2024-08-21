﻿using System;
using Final_project.Models;
using Final_project.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_project.Services.Interfaces
{
	public interface ICategoryService
	{
        Task<List<Category>> GetAllAsync();
        Task<List<CategoryVM>> GetAllOrderByDescAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(CategoryCreateVM category);
        Task<Category> GetWithProductAsync(int id);
        Task DeleteAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task EditAsync(Category category, CategoryEditVM categoryEdit);
        Task<SelectList> GetAllBySelectAsync();
    }
}

