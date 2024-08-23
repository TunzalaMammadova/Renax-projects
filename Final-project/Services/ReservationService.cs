using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public ReservationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Reservation rez)
        {
            await _context.Reservations.AddAsync(rez);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetAll()
        {
            return await _context.Reservations.Include(m => m.AppUser).Include(m => m.Car).Include(m => m.Service).ToListAsync();
        }

        public async Task<Reservation> GetById(int id)
        {
            return await _context.Reservations.Include(m => m.AppUser).Include(m => m.Car).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task Edit(int id, Reservation rez)
        {
            var existData = await GetById(id);
            existData.CarId = rez.CarId;
            existData.OrderStatus = rez.OrderStatus;
            existData.ServiceId = rez.ServiceId;
            existData.StartDate = rez.StartDate;
            existData.EndDate = rez.EndDate;

            await _context.SaveChangesAsync();
        }
    }
}

