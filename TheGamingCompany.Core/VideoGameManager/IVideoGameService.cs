using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.VideoGameManager
{
	public interface IVideoGameService
	{
        Task<OperationResult<Game>> AddAsync(Game game);

        Task<OperationResult<IReadOnlyList<Game>>> GetByCategory(int categoryId);

        OperationResult<Game> GetById(int id);

    }
}

