using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.CategoryManager
{
	public class CategoryService : ICategoryService
	{
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
		{
            this.categoryRepository = categoryRepository;
        }

        public async Task<OperationResult<Category>> AddAsync(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                return new OperationResult<Category>(new Error
                {
                    Code = ErrorCode.InternalError,
                    Message = "Name is a required field to add a category"
                });
            }
            var entity = await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.CommitAsync();
            return new OperationResult<Category>(entity);
        }
    }
}

