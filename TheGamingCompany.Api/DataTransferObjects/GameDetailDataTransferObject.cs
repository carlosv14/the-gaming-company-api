using System;
namespace TheGamingCompany.Api.DataTransferObjects
{
	public class GameDetailDataTransferObject
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Author { get; set; }

        public int GamingModeId { get; set; }

        public int Copies { get; set; }

        public int CategoryId { get; set; }
    }
}

