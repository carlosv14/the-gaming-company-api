using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.VideoGameManager
{
	public interface IVideoGameService
	{
        Task<OperationResult<Game>> AddAsync(Game game);

        OperationResult<IReadOnlyList<Game>> GetByCategory(int categoryId);
    }
}

