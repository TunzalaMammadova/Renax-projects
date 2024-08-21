using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Accounts
{
	public class ForgotPasswordVM
	{
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

