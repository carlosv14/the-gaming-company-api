﻿using System;
namespace TheGamingCompany.Core.Entities
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Game> Games { get; set; }
	}
}

