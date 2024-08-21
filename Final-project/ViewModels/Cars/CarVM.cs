using System;
using Final_project.Models;

namespace Final_project.ViewModels.Cars
{
	public class CarVM
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int Door { get; set; }
        public int Passenger { get; set; }
        public string Description { get; set; }
        public string Transmission { get; set; }
        public string Luggage { get; set; }
        public string AirCondition { get; set; }
        public int Age { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string RentalCondition { get; set; }
    }
}

