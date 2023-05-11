using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.VideoGameManager
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IRepository<Game> gameRepository;
        private readonly IRepository<GamingMode> gamingModeRepository;

        public VideoGameService(
            IRepository<Game> gameRepository,
            IRepository<GamingMode> gamingModeRepository)
        {
            this.gameRepository = gameRepository;
            this.gamingModeRepository = gamingModeRepository;
        }

        public async Task<OperationResult<Game>> AddAsync(Game game)
        {
            if (string.IsNullOrEmpty(game.Name))
            {
                return new OperationResult<Game>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Name is a required field to add a game"
                });
            }

            if (string.IsNullOrEmpty(game.Author))
            {
                return new OperationResult<Game>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Author is a required field to add a game"
                });
            }

            var gamingMode = this.gamingModeRepository.GetById(game.GamingModeId);

            if (gamingMode is null)
            {
                return new OperationResult<Game>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Gaming mode is a required field to add a game"
                });
            }

            if (game.Copies <= 0)
            {
                return new OperationResult<Game>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Copies is a required field to add a game"
                });
            }
            var entity = await this.gameRepository.AddAsync(game);
            await this.gameRepository.CommitAsync();
            return new OperationResult<Game>(entity);
        }
    }
}

