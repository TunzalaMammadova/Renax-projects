using System;
using System.ComponentModel.DataAnnotations;
using Final_project.Models;

namespace Final_project.ViewModels.Cars
{
	public class CarEditVM
	{
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price can't be empty")]
        public int Price { get; set; }
        [Required]
        public int Door { get; set; }
        [Required]
        public int Passenger { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Transmission { get; set; }
        [Required]
        public string Luggage { get; set; }
        [Required]
        public string AirCondition { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<IFormFile>? NewImages { get; set; }
        public List<CarEditImageVM>? ExistImages { get; set; }
        public List<RentalCondition>? RentalConditions { get; set; }
    }
}

