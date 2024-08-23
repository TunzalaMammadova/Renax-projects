using System;
using Final_project.Helpers.Enum;
using Final_project.Models;

namespace Final_project.ViewModels.Reservation
{
	public class ReservationVM
	{
        public int Id { get; set; }
        public string CarName { get; set; }
        public string ServiceName { get; set; }
        public string UserEmail { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}


