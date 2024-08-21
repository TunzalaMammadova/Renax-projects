using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Proccess
{
	public class ProccessVM
	{
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Number { get; set; }
    }
}

