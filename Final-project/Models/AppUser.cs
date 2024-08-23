using System;
using Microsoft.AspNetCore.Identity;

namespace Final_project.Models
{
	public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }
}

