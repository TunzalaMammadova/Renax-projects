using System;
namespace Final_project.Models
{
	public class ServiceCondition : BaseEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}

