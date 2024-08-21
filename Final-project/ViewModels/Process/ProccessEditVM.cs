using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Proccess
{
	public class ProccessEditVM
	{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Number { get; set; }
    }
}

