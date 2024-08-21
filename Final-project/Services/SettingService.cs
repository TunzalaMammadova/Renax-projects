using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Settings;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Setting setting)
        {
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Setting setting)
        {
            _context.Settings.Remove(setting);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, Setting setting)
        {
            var existData = await GetById(id);

            existData.Key = setting.Key;
            existData.Value = setting.Value;

            await _context.SaveChangesAsync();
        }

        public async Task<Dictionary<int, Dictionary<string, string>>> GetAll()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Id, m => new Dictionary<string, string> { { "Key", m.Key }, { "Value", m.Value } });
        }

        public async Task<Setting> GetById(int id)
        {
            return await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }

}

