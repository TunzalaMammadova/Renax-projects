using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Teams
{
    public class TeamCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }

}

