using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Settings
{
	public class SettingEditVM
	{
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}

