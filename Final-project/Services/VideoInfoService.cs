using System;
using Final_project.Data;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Proccess;
using Final_project.ViewModels.VideoInfos;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class VideoInfoService : IVideoInfoService
	{
        private readonly AppDbContext _context;

        public VideoInfoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VideoInfo> GetByIdAsync(int id)
        {
            return await _context.VideoInfos.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<VideoInfo>> GetAllAsync()
        {
            return await _context.VideoInfos.Where(m => !m.SoftDeleted).ToListAsync();

        }

        public async Task CreateAsync(VideoInfoCreateVM request)
        {
            await _context.VideoInfos.AddAsync(new VideoInfo
            {
                Title = request.Title,
                SubTitle = request.SubTitle,
                Name = request.Name,
                Price = request.Price

            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(VideoInfo videoInfo)
        {
            _context.VideoInfos.Remove(videoInfo);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(VideoInfo videoInfo, VideoInfoEditVM editVM)
        {
            videoInfo.Title = editVM.Title;
            videoInfo.SubTitle = editVM.SubTitle;
            videoInfo.Name = editVM.Name;
            videoInfo.Price = editVM.Price;

            await _context.SaveChangesAsync();
        }

        public async Task<List<VideoInfoVM>> GetAllOrderByDescAsync()
        {
            List<VideoInfo> videoInfos = await _context.VideoInfos.OrderByDescending(m => m.Id).ToListAsync();


            return videoInfos.Select(m => new VideoInfoVM
            {

                Id = m.Id,
                Title = m.Title,
                SubTitle = m.SubTitle,
                Name = m.Name,
                Price = m.Price,

            }).ToList();
        }
    }
}


