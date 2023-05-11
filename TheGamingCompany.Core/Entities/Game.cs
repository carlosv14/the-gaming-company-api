using System;
namespace TheGamingCompany.Core.Entities
{
	public class Game
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime PublishedOn { get; set; }

		public string Author { get; set; }

		public GamingMode GamingMode { get; set; }

		public int GamingModeId { get; set; }

		public int Copies { get; set; }

		public Category Category { get; set; }

		public int CategoryId { get; set; }
	}
}

