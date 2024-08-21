using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.ServiceCondition;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class ServiceConditionService : IServiceConditionService
    {
        private readonly AppDbContext _context;

        public ServiceConditionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceCondition> GetByIdAsync(int id)
        {
            return await _context.ServiceConditions.Include(m => m.Service)
                                                   .Where(m => m.Id == id)
                                                   .FirstOrDefaultAsync();
        }

        public async Task<List<ServiceCondition>> GetAllAsync()
        {
            return await _context.ServiceConditions.Include(m => m.Service)
                                                   .Where(m => !m.SoftDeleted)
                                                   .ToListAsync();

        }

        public async Task CreateAsync(ServiceConditionCreateVM request)
        {
            await _context.ServiceConditions.AddAsync(new ServiceCondition
            {
                Title = request.Title,
                Description = request.Description,
                ServiceId = request.ServiceId

            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceCondition service)
        {
            _context.ServiceConditions.Remove(service);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(ServiceCondition service, ServiceConditionEditVM editVM)
        {
            service.Title = editVM.Title;
            service.Description = editVM.Description;
            service.ServiceId = editVM.ServiceId;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceConditionVM>> GetAllOrderByDescAsync()
        {
            List<ServiceCondition> rental = await _context.ServiceConditions.OrderByDescending(m => m.Id).ToListAsync();

            return rental.Select(m => new ServiceConditionVM
            {

                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ServiceId = m.ServiceId

            }).ToList();
        }
    }
}


