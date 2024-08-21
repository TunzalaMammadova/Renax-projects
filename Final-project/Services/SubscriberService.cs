using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class SubscriberService : ISubscriberService
    {
        private readonly AppDbContext _context;
        public SubscriberService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Subscriber subscriber)
        {
            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Subscriber subscriber)
        {
            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subscriber>> GetAll()
        {
            return await _context.Subscribers.ToListAsync();
        }

        public async Task<Subscriber> GetById(int id)
        {
            return await _context.Subscribers.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}


