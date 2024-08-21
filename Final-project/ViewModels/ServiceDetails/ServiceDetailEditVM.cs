using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.ServiceDetails
{
	public class ServiceDetailEditVM
	{
        [Required]
        public string Description { get; set; }
        [Required]
        public string Options { get; set; }
        [Required]
        public string OptionDescription { get; set; }
        [Required]
        public string Booking { get; set; }
        [Required]
        public string BookingDescription { get; set; }
        [Required]
        public string Luggage { get; set; }
        [Required]
        public string LuggageDescription { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}

