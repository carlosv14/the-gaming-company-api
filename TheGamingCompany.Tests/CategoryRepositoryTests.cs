using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TheGamingCompany.Core.Entities;
using TheGamingCompany.Infrastructure.Database;
using TheGamingCompany.Infrastructure.Database.Repositories;

namespace TheGamingCompany.Tests;

public class CategoryRepositoryTests
{
    private readonly TheGamingCompanyContext context;
    public CategoryRepositoryTests()
    {
        var categories = new List<Category>
        {
            new Category
            {
                Name = "Category 1",
                Id = 1
            },
            new Category
            {
                Name = "Category 2",
                Id = 2
            },
            new Category
            {
                Name = "Category 3",
                Id = 3
            },
            new Category
            {
                Name = "New category",
                Id = 4
            }
        };
        context = GetTheGamingCompanyContext(categories, "database");
    }
    
    [Theory]
    [InlineData("Category 1", 1)]
    [InlineData("Category", 3)]
    public void FilterByName_ReturnsCorrectResults(string name, int expectedCount)
    {
        //arrange
        var repository = new BaseRepository<Category>(context);
        
        // act
        var result = 
            repository.Filter(x => x.Name.StartsWith(name));
        
        //assert
        result.Count.Should().Be(expectedCount);
    }

    private static TheGamingCompanyContext GetTheGamingCompanyContext(List<Category> categories, string name)
    {
        var contextOptions = new DbContextOptionsBuilder<TheGamingCompanyContext>()
            .UseInMemoryDatabase(databaseName: name)
            .Options;

        var context = new TheGamingCompanyContext(contextOptions);
        context.Database.EnsureDeleted();
        context.Categories.AddRange(categories);
        context.SaveChanges();
        return context;
    }
}