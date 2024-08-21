using System;

namespace Final_project.Models
{
	public class RentalCondition : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}

