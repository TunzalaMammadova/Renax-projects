using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.About
{
	public class AboutCreateVM
	{
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

