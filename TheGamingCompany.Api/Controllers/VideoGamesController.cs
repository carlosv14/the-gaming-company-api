using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core;
using TheGamingCompany.Core.VideoGameManager;

namespace TheGamingCompany.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : TheGamingCompanyBaseController
	{
        private readonly IVideoGameService videoGameService;
        private readonly IMapper mapper;

        public VideoGamesController(IVideoGameService videoGameService, IMapper mapper)
        {
            this.videoGameService = videoGameService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddGameAsync(AddGameDataTransferObject gameToAdd)
        {
            var result = await this.videoGameService.AddAsync(this.mapper.Map<Core.Entities.Game>(gameToAdd));
            var addedGame = this.mapper.Map<GameDetailDataTransferObject>(result.Result);
            return result.Succeeded ? Ok(addedGame) : GetErrorResult<Core.Entities.Game>(result);
        }
    }
}

