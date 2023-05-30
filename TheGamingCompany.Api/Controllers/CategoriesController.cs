using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core;
using TheGamingCompany.Core.CategoryManager;
using TheGamingCompany.Core.ConversationalLanguageInterpreter;
using TheGamingCompany.Core.VideoGameManager;

namespace TheGamingCompany.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : TheGamingCompanyBaseController
{
    private readonly ICategoryService categoryService;
    private readonly IVideoGameService videoGameService;
    private readonly ILanguageInterpreter _languageInterpreter;
    private readonly IMapper mapper;

    public CategoriesController(
        ICategoryService categoryService,
        IVideoGameService videoGameService,
        ILanguageInterpreter languageInterpreter,
        IMapper mapper)
    {
        this.categoryService = categoryService;
        this.videoGameService = videoGameService;
        _languageInterpreter = languageInterpreter;
        this.mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoryAsync(AddCategoryDataTransferObject categoryToAdd)
    {
        var result = await this.categoryService.AddAsync(new Core.Entities.Category
        {
            Name = categoryToAdd.Name
        });
        return result.Succeeded ? Ok(result.Result) : GetErrorResult<Core.Entities.Category>(result);
    }

    [HttpGet("{categoryId}/games")]
    public async Task<IActionResult> GetGamesByCategoryAsync(int categoryId)
    {
        await _languageInterpreter.InterpretAsync("Buy 2 pepperoni pizzas");
        var result = await this.videoGameService.GetByCategory(categoryId);
        var games = this.mapper.Map<IList<GameDetailDataTransferObject>>(result.Result);
        return result.Succeeded ? Ok(games) : GetErrorResult<IReadOnlyList<Core.Entities.Game>>(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var result = await this.categoryService.GetAllAsync();
        var categories = this.mapper.Map<IList<CategoryDetailDataTransferObject>>(result.Result);
        return result.Succeeded ? Ok(categories) : GetErrorResult<IReadOnlyList<Core.Entities.Category>>(result);
    }
}

