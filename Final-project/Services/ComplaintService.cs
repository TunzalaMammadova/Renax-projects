using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
    public class ComplaintService : IComplaintService
    {
        protected readonly AppDbContext _context;

        public ComplaintService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ComplaintSuggest suggest)
        {
            await _context.ComplaintSuggests.AddAsync(suggest);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ComplaintSuggest suggest)
        {
            _context.ComplaintSuggests.Remove(suggest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ComplaintSuggest>> GetAllAsync()
        {
            return await _context.ComplaintSuggests.ToListAsync();
        }

        public async Task<ComplaintSuggest> GetById(int id)
        {
            return await _context.ComplaintSuggests.FirstOrDefaultAsync(m => m.Id == id); ;
        }
    }
}

