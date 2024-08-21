using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Videos
{
	public class VideoCreateVM
	{
        [Required]
        public IFormFile Video { get; set; }
    }
}

