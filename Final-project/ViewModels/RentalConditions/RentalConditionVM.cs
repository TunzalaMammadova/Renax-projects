﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Final_project.ViewModels.RentalConditions
{
	public class RentalConditionVM
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
    }
}

