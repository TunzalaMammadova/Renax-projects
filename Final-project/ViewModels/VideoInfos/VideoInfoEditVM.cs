using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.VideoInfos
{
	public class VideoInfoEditVM
	{
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}

