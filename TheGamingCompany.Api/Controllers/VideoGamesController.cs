using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core;
using TheGamingCompany.Core.LoanManager;
using TheGamingCompany.Core.VideoGameManager;

namespace TheGamingCompany.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : TheGamingCompanyBaseController
	{
        private readonly IVideoGameService videoGameService;
        private readonly ILoanService loanService;
        private readonly IMapper mapper;

        public VideoGamesController(
            IVideoGameService videoGameService,
            ILoanService loanService,
            IMapper mapper)
        {
            this.videoGameService = videoGameService;
            this.loanService = loanService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddGameAsync(AddGameDataTransferObject gameToAdd)
        {
            var result = await this.videoGameService.AddAsync(this.mapper.Map<Core.Entities.Game>(gameToAdd));
            var addedGame = this.mapper.Map<GameDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(addedGame) : GetErrorResult<Core.Entities.Game>(result);
        }

        [HttpPost("{gameId}/loans")]
        public async Task<IActionResult> LoanGameAsync(int gameId)
        {
            var result = await this.loanService.LoanGameAsync(gameId);
            var addedGame = this.mapper.Map<LoanDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(addedGame) : GetErrorResult<Core.Entities.Loan>(result);
        }

        [HttpDelete("{gameId}/loans")]
        public async Task<IActionResult> ReturnGameAsync(int gameId)
        {
            var result = await this.loanService.ReturnGameAsync(gameId);
            var addedGame = this.mapper.Map<LoanDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(addedGame) : GetErrorResult<Core.Entities.Loan>(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            var result = this.videoGameService.GetById(id);
            var game = this.mapper.Map<GameDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(game) : GetErrorResult<Core.Entities.Game>(result);
        }
    }
}

