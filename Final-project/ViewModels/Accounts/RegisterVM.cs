using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Accounts
{
	public class RegisterVM
	{

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Fullname { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

