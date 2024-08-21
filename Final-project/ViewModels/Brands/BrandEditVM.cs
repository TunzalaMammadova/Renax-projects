using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Brands
{
	public class BrandEditVM
	{
        [Required]
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}

