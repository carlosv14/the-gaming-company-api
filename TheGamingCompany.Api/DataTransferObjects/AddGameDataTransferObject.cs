using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Api.DataTransferObjects
{
	public class AddGameDataTransferObject
	{
        public string Name { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Author { get; set; }

        public int GamingModeId { get; set; }

        public int Copies { get; set; }

        public int CategoryId { get; set; }
    }
}

