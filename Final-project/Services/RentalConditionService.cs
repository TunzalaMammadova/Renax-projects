using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.RentalConditions;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class RentalConditionService : IRentalConditionService
    {
        private readonly AppDbContext _context;

        public RentalConditionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RentalCondition> GetByIdAsync(int id)
        {
            return await _context.RentalConditions.Include(m => m.Car)
                                                  .Where(m => m.Id == id)
                                                  .FirstOrDefaultAsync();
        }

        public async Task<List<RentalCondition>> GetAllAsync()
        {
            return await _context.RentalConditions.Include(m => m.Car)
                                                  .Where(m => !m.SoftDeleted)
                                                  .ToListAsync();

        }

        public async Task CreateAsync(RentalConditionCreateVM request)
        {
            await _context.RentalConditions.AddAsync(new RentalCondition
            {
                Title = request.Title,
                Description = request.Description,
                CarId = request.CarId
                
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RentalCondition rental)
        {
            _context.RentalConditions.Remove(rental);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(RentalCondition rental, RentalConditionEditVM editVM)
        {
            rental.Title = editVM.Title;
            rental.Description = editVM.Description;
            rental.CarId = editVM.CarId;

            await _context.SaveChangesAsync();
        }

        public async Task<List<RentalConditionVM>> GetAllOrderByDescAsync()
        {
            List<RentalCondition> rental = await _context.RentalConditions.OrderByDescending(m => m.Id).ToListAsync();

            return rental.Select(m => new RentalConditionVM
            {

                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                CarId = m.CarId

            }).ToList();
        }
    }
}


