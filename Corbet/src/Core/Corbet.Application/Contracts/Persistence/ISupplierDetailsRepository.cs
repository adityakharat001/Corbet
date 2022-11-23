using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.SuppliersDetails.Command.DeleteSupplierDetails;
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
        public Task<DeleteSupplierDetailsCommandDto> RemoveSupplierDetailsAsync(int supplierId);
        public Task<bool> ToggleActiveStatus(int supplierId);
        public Supplier SupplierDetailsAdding(SupplierDetails supplierDetails);
    }
}
