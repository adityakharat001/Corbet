using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.Suppliers.Commands.DeleteSupplier;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ISupplierRepository:IAsyncRepository<Supplier>
    {
        public Task<DeleteSupplierCommandDto> RemoveSupplierAsync(int supplierId);
        public Task<bool> ToggleActiveStatus(int supplierId);
    }
}
