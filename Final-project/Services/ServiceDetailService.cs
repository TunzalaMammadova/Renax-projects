using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.ServiceDetails;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
    public class ServiceDetailService : IServiceDetailService
    {
        private readonly AppDbContext _context;

        public ServiceDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceDetail> GetByIdAsync(int id)
        {
            return await _context.ServiceDetails.Include(m => m.Service)
                                                .Where(m => m.Id == id)
                                                .FirstOrDefaultAsync();
        }

        public async Task<List<ServiceDetail>> GetAllAsync()
        {
            return await _context.ServiceDetails.Include(m => m.Service)
                                                .Where(m => !m.SoftDeleted)
                                                .ToListAsync();

        }

        public async Task CreateAsync(ServiceDetailCreateVM request)
        {
            await _context.ServiceDetails.AddAsync(new ServiceDetail
            {
                Description = request.Description,
                Options = request.Options,
                OptionDescription = request.OptionDescription,
                Booking = request.Booking,
                BookingDescription = request.BookingDescription,
                Luggage = request.Luggage,
                LuggageDescription = request.LuggageDescription,
                ServiceId = request.ServiceId

            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceDetail detail)
        {
            _context.ServiceDetails.Remove(detail);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(ServiceDetail detail, ServiceDetailEditVM editVM)
        {
            detail.Description = editVM.Description;
            detail.Options = editVM.Options;
            detail.OptionDescription = editVM.OptionDescription;
            detail.Booking = editVM.Booking;
            detail.BookingDescription = editVM.BookingDescription;
            detail.Luggage = editVM.Luggage;
            detail.LuggageDescription = editVM.LuggageDescription;
            detail.ServiceId = editVM.ServiceId;
            detail.ServiceId = editVM.ServiceId;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceDetailVM>> GetAllOrderByDescAsync()
        {
            List<ServiceDetail> detail = await _context.ServiceDetails.OrderByDescending(m => m.Id).ToListAsync();

            return detail.Select(m => new ServiceDetailVM
            {

                Id = m.Id,
                Description = m.Description,
                Options = m.Options,
                OptionDescription = m.OptionDescription,
                Booking = m.Booking,
                BookingDescription = m.BookingDescription,
                Luggage = m.Luggage,
                LuggageDescription = m.LuggageDescription,
                ServiceId = m.ServiceId

            }).ToList();
        }

    }
}


