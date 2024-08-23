namespace Final_project.Models
{
	public class Service : BaseEntity
	{
		public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<ServiceDetail> ServiceDetails { get; set; }
        public ICollection<ServiceCondition> ServiceConditions { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}

