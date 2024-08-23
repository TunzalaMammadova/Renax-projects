using System;
using Microsoft.AspNetCore.Identity;

namespace Final_project.ViewModels.UserAdmin
{
    public class UserVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public RemoveRoleVM removeRole { get; set; }
    }
}

