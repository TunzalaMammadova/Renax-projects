using System;
using Final_project.Data;
using Final_project.Helpers.Extensions;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Videos;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Services
{
	public class VideoService : IVideoService
	{
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public VideoService(AppDbContext context,
                            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _context.Videos.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Video>> GetAllAsync()
        {
            return await _context.Videos.Where(m => !m.SoftDeleted).ToListAsync();

        }

        public async Task CreateAsync(VideoCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Video.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets/image", fileName);

            await request.Video.SaveFileToLocalAsync(path);

            await _context.Videos.AddAsync(new Video { BackgroundVideo = fileName });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Video video)
        {
            string path = Path.Combine(_env.WebRootPath, "assets/image", video.BackgroundVideo);

            path.DeleteFileFromToLocal();

            _context.Videos.Remove(video);

            await _context.SaveChangesAsync();
        }


        public async Task EditAsync(Video video, VideoEditVM editVM)
        {

            if (editVM.NewVideo is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "assets/image", video.BackgroundVideo);

                oldPath.DeleteFileFromToLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + editVM.NewVideo.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "assets/image", fileName);

                await editVM.NewVideo.SaveFileToLocalAsync(newPath);

                video.BackgroundVideo = fileName;
            }

            await _context.SaveChangesAsync();
        }


        public async Task<List<VideoVM>> GetAllOrderByDescAsync()
        {
            List<Video> videos = await _context.Videos.OrderByDescending(m => m.Id).ToListAsync();

            return videos.Select(m => new VideoVM
            {
                Id = m.Id,
                Video = m.BackgroundVideo,

            }).ToList();
        }

    }
}


