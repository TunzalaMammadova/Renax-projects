using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.RentalConditions
{
	public class RentalConditionCreateVM
	{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CarId { get; set; }
    }
}

