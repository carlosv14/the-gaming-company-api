using System;
namespace TheGamingCompany.Core.Entities
{
	public class Loan
	{
		public int Id { get; set; }

		public int GameId { get; set; }

		public Game Game { get; set; }

		public bool IsReturnOperation { get; set; }
	}
}

