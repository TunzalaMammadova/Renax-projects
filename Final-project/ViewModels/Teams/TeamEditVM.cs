using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Teams
{
    public class TeamEditVM
    {
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }

}

