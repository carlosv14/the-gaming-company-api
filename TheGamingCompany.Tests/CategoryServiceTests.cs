using FluentAssertions;
using Moq;
using TheGamingCompany.Core;
using TheGamingCompany.Core.CategoryManager;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Tests;

public class CategoryServiceTests
{
    [Fact]
    public async Task AddAsync_ValidName_Succeeds()
    {
        //arrange
        var category = new Category
        {
            Name = "Category 1",
            Id = 1
        };
        
        var categoryRepositoryMock = new Mock<IRepository<Category>>();
        categoryRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Category>()))
            .ReturnsAsync(category);

        categoryRepositoryMock
            .Setup(x => x.CommitAsync())
            .ReturnsAsync(1);
        
        var categoryService = new CategoryService(categoryRepositoryMock.Object);
        
        // act
        var result = await categoryService.AddAsync(category);
        Assert.True(result.Succeeded);
        Assert.Equal("Category 1", result.Result.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task AddAsync_InvalidName_Fails(string? name)
    {
        //arrange
        var category = new Category
        {
            Name = name,
            Id = 1
        };
        var categoryRepositoryMock = new Mock<IRepository<Category>>();
        var categoryService = new CategoryService(categoryRepositoryMock.Object);
        
        //act
        var result = await categoryService.AddAsync(category);
        
        //assert
        // Assert.False(result.Succeeded);
        // Assert.Equal("Name is a required field to add a category", result.Error.Message);

        result.Succeeded.Should().BeFalse();
        result.Error.Message.Should().Be("Name is a required field to add a category");
    }
}