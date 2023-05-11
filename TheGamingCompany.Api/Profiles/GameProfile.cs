using System;
using AutoMapper;
using TheGamingCompany.Api.DataTransferObjects;

namespace TheGamingCompany.Api.Profiles
{
	public class GameProfile : Profile
	{
		public GameProfile()
		{
			CreateMap<AddGameDataTransferObject, Core.Entities.Game>();
			CreateMap<Core.Entities.Game, GameDetailDataTransferObject>();
        }
	}
}

