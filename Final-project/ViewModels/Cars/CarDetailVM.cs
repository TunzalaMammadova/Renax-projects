using System;
using Final_project.Models;

namespace Final_project.ViewModels.Cars
{
	public class CarDetailVM
	{
        public string Name { get; set; }
        public int Price { get; set; }
        public int Door { get; set; }
        public int Passenger { get; set; }
        public string Description { get; set; }
        public string Transmission { get; set; }
        public string Luggage { get; set; }
        public string AirCondition { get; set; }
        public int Age { get; set; }
        public string Category { get; set; }
        public List<CarImageVM> Images { get; set; }
    }
}

