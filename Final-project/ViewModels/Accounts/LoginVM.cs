using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.Accounts
{
    public class LoginVM
    {
        [Required]
        public string UserNameorEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}


