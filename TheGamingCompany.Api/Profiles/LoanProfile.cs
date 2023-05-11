using System;
using AutoMapper;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Api.Profiles
{
	public class LoanProfile : Profile
	{
		public LoanProfile()
		{
			CreateMap<Loan, LoanDetailDataTransferObject>();
		}
	}
}

