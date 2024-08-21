using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.ServiceCondition
{
	public class ServiceConditionDetailVM
	{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Service { get; set; }
    }
}

