using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TheGamingCompany.Api.Controllers;
using TheGamingCompany.Api.DataTransferObjects;
using TheGamingCompany.Core;
using TheGamingCompany.Core.CategoryManager;
using TheGamingCompany.Core.Entities;
using TheGamingCompany.Core.VideoGameManager;

namespace TheGamingCompany.Tests;

public class CategoriesControllerTests
{
    [Fact]
    public async Task GetCategoriesAsync_SuccessfulResult_ReturnsOk()
    {
        //arrange
        var categoriesToReturn = 
            new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Action"
                }
            };
        var categoryServiceMock = new Mock<ICategoryService>();
        categoryServiceMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(
                 new OperationResult<IReadOnlyList<Category>>(
                     categoriesToReturn));
        
        var videoGameServiceMock = new Mock<IVideoGameService>();
        var mapperMock = new Mock<IMapper>();
        mapperMock
            .Setup(x => x.Map<IList<CategoryDetailDataTransferObject>>(
                It.IsAny<IReadOnlyList<Category>>()))
            .Returns(
                    categoriesToReturn.Select(x => new CategoryDetailDataTransferObject
                    {
                        Id =x.Id,
                        Name = x.Name
                    }).ToList()
            );
        
        var controller = new CategoriesController(
                categoryServiceMock.Object,
                videoGameServiceMock.Object,
                mapperMock.Object
            );
        
        //act
        var result = await controller.GetCategoriesAsync();
        
        //assert
        Assert.IsType<OkObjectResult>(result);
    } 
    
    [Fact]
    public async Task GetCategoriesAsync_UnsuccessfulResult_ReturnsError()
    {
        //arrange
        var categoryServiceMock = new Mock<ICategoryService>();
        categoryServiceMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(new OperationResult<IReadOnlyList<Category>>(new Error
            {
                Code = ErrorCode.InternalError,
                Message = "Internal error"
            }));
        
        var videoGameServiceMock = new Mock<IVideoGameService>();
        var mapperMock = new Mock<IMapper>();
        mapperMock
            .Setup(x => x.Map<IList<CategoryDetailDataTransferObject>>(
                It.IsAny<IReadOnlyList<Category>>()))
            .Returns(new List<CategoryDetailDataTransferObject>());
        
        var controller = new CategoriesController(
            categoryServiceMock.Object,
            videoGameServiceMock.Object,
            mapperMock.Object
        );
        
        //act
        var result = await controller.GetCategoriesAsync();
        
        //assert
        var typedResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Internal error", typedResult.Value);
    } 
}
