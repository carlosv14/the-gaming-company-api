using System;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Core.CategoryManager
{
	public interface ICategoryService
	{
		Task<OperationResult<Category>> AddAsync(Category category);
	}
}

