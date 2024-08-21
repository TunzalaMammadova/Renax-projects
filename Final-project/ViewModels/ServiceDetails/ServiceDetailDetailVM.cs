using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.ServiceDetails
{
	public class ServiceDetailDetailVM
	{
        public string Description { get; set; }
        public string Options { get; set; }
        public string OptionDescription { get; set; }
        public string Booking { get; set; }
        public string BookingDescription { get; set; }
        public string Luggage { get; set; }
        public string LuggageDescription { get; set; }
        public string Service{ get; set; }
    }
}

