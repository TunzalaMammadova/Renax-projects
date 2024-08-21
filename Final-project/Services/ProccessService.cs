using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Proccess;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class ProccessService : IProccessService
	{
        private readonly AppDbContext _context;

        public ProccessService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Process> GetByIdAsync(int id)
        {
            return await _context.Processes.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Process>> GetAllAsync()
        {
            return await _context.Processes.Where(m => !m.SoftDeleted).ToListAsync();

        }

        public async Task CreateAsync(ProcessCreateVM request)
        {
            await _context.Processes.AddAsync(new Process
            {
                Title = request.Title,
                Description = request.Description,
                Number = request.Number,

            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Process process)
        {
            _context.Processes.Remove(process);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Process process, ProccessEditVM editVM)
        {
            process.Title = editVM.Title;
            process.Description = editVM.Description;
            process.Number = editVM.Number;
         
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProccessVM>> GetAllOrderByDescAsync()
        {
            List<Process> processes = await _context.Processes.OrderByDescending(m => m.Id).ToListAsync();

            return processes.Select(m => new ProccessVM
            {

                Id = m.Id,
                Title= m.Title,
                Description = m.Description,
                Number = m.Number,

            }).ToList();
        }
    }
}


