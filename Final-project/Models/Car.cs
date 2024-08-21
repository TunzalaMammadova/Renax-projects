namespace Final_project.Models
{
	public class Car : BaseEntity
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
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<CarImage> CarImages { get; set; }
		public ICollection <RentalCondition> RentalConditions{ get; set; }
	}
}

