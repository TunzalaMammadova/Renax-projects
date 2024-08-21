using System;
namespace Final_project.Models
{
	public class Process : BaseEntity
	{
		public string Title { get; set; }
        public string Description { get; set; }
		public int Number { get; set; }
	}
}

