using Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IProductCategoryRepo : IAsyncRepository<ProductCategory>
    {
        public Task<bool> CheckCategoryExists(string categoryName);
        public Task<List<ProductCategory>> GetAllCategories();
        public Task<DeleteProductCategoryCommandDto> RemoveCategoryAsync(int categoryId);
    }
}
