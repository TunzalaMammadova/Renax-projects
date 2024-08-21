using System;
using Final_project.Models;
using Final_project.ViewModels.VideoInfos;

namespace Final_project.Services.Interfaces
{
	public interface IVideoInfoService
	{
        Task<VideoInfo> GetByIdAsync(int id);
        Task<List<VideoInfo>> GetAllAsync();
        Task<List<VideoInfoVM>> GetAllOrderByDescAsync();
        Task CreateAsync(VideoInfoCreateVM customer);
        Task DeleteAsync(VideoInfo videoInfo);
        Task EditAsync(VideoInfo videoInfo, VideoInfoEditVM editVM);
    }
}

