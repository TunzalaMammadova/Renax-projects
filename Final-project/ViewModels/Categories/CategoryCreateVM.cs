using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Categories
{
	public class CategoryCreateVM
	{
        [Required]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(10, ErrorMessage = "Length must be max 20")]
        public string Name { get; set; }
    }
}

