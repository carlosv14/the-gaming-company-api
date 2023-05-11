using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.LoanManager
{
	public interface ILoanService
	{
		Task<OperationResult<Loan>> LoanGameAsync(int gameId); 
		Task<OperationResult<Loan>> ReturnGameAsync(int gameId, int loanId);
		Task<OperationResult<IReadOnlyList<Loan>>> GetAllAsync();
    }
}

