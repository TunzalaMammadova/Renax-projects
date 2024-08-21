using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.About
{
	public class AboutEditVM
	{
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

