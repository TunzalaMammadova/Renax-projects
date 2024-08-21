using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Videos
{
	public class VideoEditVM
	{
        [Required]
        public string? Video { get; set; }
        public IFormFile? NewVideo { get; set; }
    }
}

