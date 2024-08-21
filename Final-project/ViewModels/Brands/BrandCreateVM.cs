using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Brands
{
	public class BrandCreateVM
	{
        [Required]
        public IFormFile Image { get; set; }
    }
}

