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
    }
}
