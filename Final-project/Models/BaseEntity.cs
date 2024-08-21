﻿using System;
namespace Final_project.Models
{
	public abstract class BaseEntity
	{
        public int Id { get; set; }
        public bool SoftDeleted { get; set; } = false;
    }
}

