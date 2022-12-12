using Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryByCategoryId;
using Corbet.Application.Features.ProductSubCategory.Command.DeleteSubCategory;
using Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryList;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IProductSubCategoryRepo:IAsyncRepository<ProductSubCategory>
    {
        Task<List<GetCategoryQueryVm>> GetAllSubCategoryDetail();
        bool SubCategoryExist(ProductSubCategory productSubCategory);
        List<GetSubCategoryByCategoryIdVm> GetSubCategoryByCategoryId(int categoryId);
        Task<DeleteSubCategoryDto> RemoveSubCategoryAsync(int Id, int? DeletedBy);
        public Task<bool> ToggleActiveStatus(int id);

    }
}
