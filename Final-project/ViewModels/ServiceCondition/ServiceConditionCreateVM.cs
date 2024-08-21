using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.ServiceCondition
{
	public class ServiceConditionCreateVM
	{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}

