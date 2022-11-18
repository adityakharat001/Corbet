using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ICategoryDetailsRepo : IAsyncRepository<ProductCategoryDetail>
    {
        public Task<DeleteCategoryDetailsCommandDto> RemoveCategoryDetailsAsync(int id);
        public Task<List<GetAllCategoryDetailsListVm>> GetAllCategoryDetails();
    }
}
