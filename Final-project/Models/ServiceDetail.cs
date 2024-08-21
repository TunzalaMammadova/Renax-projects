using System;
namespace Final_project.Models
{
	public class ServiceDetail : BaseEntity
	{
		public string Description { get; set; }
		public string Options { get; set; }
        public string OptionDescription { get; set; }
        public string Booking { get; set; }
        public string BookingDescription { get; set; }
        public string Luggage { get; set; }
        public string LuggageDescription { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}

