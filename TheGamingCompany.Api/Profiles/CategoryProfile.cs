using System;
using AutoMapper;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Api.Profiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryDetailDataTransferObject>();
		}
	}
}

