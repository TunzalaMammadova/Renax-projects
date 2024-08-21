using System;
namespace Final_project.Models
{
	public class CarImage : BaseEntity
	{
		public string Image{ get; set; }
		public bool IsMain { get; set; } = false;
		public int CarId { get; set; }
		public Car Car { get; set; }
	}
}

