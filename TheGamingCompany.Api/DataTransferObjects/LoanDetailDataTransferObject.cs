using System;
namespace TheGamingCompany.Api.DataTransferObjects
{
	public class LoanDetailDataTransferObject
	{
        public int Id { get; set; }

        public int GameId { get; set; }

        public bool IsReturnOperation { get; set; }
    }
}

