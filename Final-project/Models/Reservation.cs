using System;
using Final_project.Helpers.Enum;

namespace Final_project.Models
{
	public class Reservation : BaseEntity
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}

