using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.RentalConditions
{
	public class RentalConditionDetailVM
	{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Car { get; set; }
    }
}

