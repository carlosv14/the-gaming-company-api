using Microsoft.AspNetCore.Mvc;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core;
using TheGamingCompany.Core.CategoryManager;

namespace TheGamingCompany.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : TheGamingCompanyBaseController
{
    private readonly ICategoryService categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
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
}

