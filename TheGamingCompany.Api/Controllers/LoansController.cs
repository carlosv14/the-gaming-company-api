using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core.LoanManager;

namespace TheGamingCompany.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LoansController : TheGamingCompanyBaseController
	{
        private readonly ILoanService loanService;
        private readonly IMapper mapper;

        public LoansController(ILoanService loanService, IMapper mapper)
		{
            this.loanService = loanService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoansAsync()
        {
            var result = await this.loanService.GetAllAsync();
            var loans = this.mapper.Map<IList<LoanDetailDataTransferObject>>(result.Result);
            return result.Succeeded ? Ok(loans) : GetErrorResult<IReadOnlyList<Core.Entities.Loan>>(result);
        }
    }
}

