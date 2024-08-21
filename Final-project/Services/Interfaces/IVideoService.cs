using System;
using Final_project.Models;
using Final_project.ViewModels.Videos;

namespace Final_project.Services.Interfaces
{
	public interface IVideoService
	{
        Task<Video> GetByIdAsync(int id);
        Task<List<Video>> GetAllAsync();
        Task<List<VideoVM>> GetAllOrderByDescAsync();
        Task CreateAsync(VideoCreateVM request);
        Task DeleteAsync(Video video);
        Task EditAsync(Video video, VideoEditVM editVM);
    }
}

