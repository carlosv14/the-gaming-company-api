using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.LoanManager
{
	public class LoanService : ILoanService
	{
        private readonly IRepository<Game> gameRepository;
        private readonly IRepository<Loan> loanRepository;

        public LoanService(IRepository<Game> gameRepository, IRepository<Loan> loanRepository)
		{
            this.gameRepository = gameRepository;
            this.loanRepository = loanRepository;
        }

        public async Task<OperationResult<IReadOnlyList<Loan>>> GetAllAsync() => (await this.loanRepository.AllAsync()).ToList();

        public async Task<OperationResult<Loan>> LoanGameAsync(int gameId)
        {
            var game = this.gameRepository.GetById(gameId);
            if (game is null || game.Copies < 3)
            {
                return new OperationResult<Loan>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "The game you're trying to rent doesn't exist or has no available copies"
                });
            }

            game.Copies -= 1;

            var loan = await this.loanRepository.AddAsync(new Loan
            {
                GameId = gameId,
                IsReturnOperation = false
            });

            await this.loanRepository.CommitAsync();
            return loan;
        }

        public async Task<OperationResult<Loan>> ReturnGameAsync(int gameId, int loanId)
        {
            var game = this.gameRepository.GetById(gameId);
            if (game is null)
            {
                return new OperationResult<Loan>(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = "The game you're trying to return doesn't exist"
                });
            }

            game.Copies += 1;

            var loan = await this.loanRepository.AddAsync(new Loan
            {
                GameId = gameId,
                IsReturnOperation = true
            });

            await this.loanRepository.CommitAsync();
            return loan;
        }
    }
}

