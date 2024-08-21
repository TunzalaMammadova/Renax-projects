using System;
using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Transfer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class TransferService : ITransferService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TransferService(AppDbContext context,
                               IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task CreateAsync(TransferCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Services.AddAsync(new Service { Name = request.Name, Image = fileName, Description = request.Description });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Service service)
        {
            string path = Path.Combine(_env.WebRootPath, "assets/image",service.Image, service.Name,service.Description);

            path.DeleteFileFromToLocal();

            _context.Services.Remove(service);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Service service, TransferEditVM transferEdit)
        {

            if (transferEdit.NewImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "assets/image", transferEdit.Image);

                oldPath.DeleteFileFromToLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + transferEdit.NewImage.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await transferEdit.NewImage.SaveFileToLocalAsync(newPath);

                service.Image = fileName;
            }

            service.Name = transferEdit.Name;
            service.Description = transferEdit.Description;


            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Services.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<SelectList> GetAllBySelectAsync()
        {
            var services = await _context.Services.ToListAsync();
            return new SelectList(services, "Id", "Name");
        }

        public async Task<List<TransferVM>> GetAllOrderByDescAsync()
        {
            List<Service> services = await _context.Services.OrderByDescending(m => m.Id).ToListAsync();
            return services.Select(m => new TransferVM { Id = m.Id, Name = m.Name,Description = m.Description, Image = m.Image }).ToList();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.Where(m => m.Id == id)
                                          .Include(m => m.ServiceConditions)
                                          .Include(m => m.ServiceDetails)
                                          .FirstOrDefaultAsync();
        }

        public async Task<Service> GetWithProductAsync(int id)
        {
            return await _context.Services.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}


