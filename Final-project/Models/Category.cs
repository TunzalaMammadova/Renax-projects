using System;
namespace Final_project.Models
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public string Image { get; set; }
		public ICollection<Car> Cars { get; set; }
	}
}