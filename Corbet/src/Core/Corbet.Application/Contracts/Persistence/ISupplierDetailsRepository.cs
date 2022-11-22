using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;

using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ISupplierDetailsRepository : IAsyncRepository<SupplierDetails>
    {
        public Task<DeleteCategoryDetailsCommandDto> RemoveSupplierDetailsAsync(int supplierId);
        public Task<bool> ToggleActiveStatus(int supplierId);
    }
}
