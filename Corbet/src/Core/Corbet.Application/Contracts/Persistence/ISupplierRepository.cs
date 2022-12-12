using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.Suppliers.Commands.DeleteSupplier;
using Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ISupplierRepository:IAsyncRepository<Supplier>
    {
        Task<bool> CheckSupplierExists(string supplier);
        public Task<DeleteSupplierCommandDto> RemoveSupplierAsync(int supplierId, int? deletedBy);
        public List<Supplier> GetAllSuppliers();
        public List<Supplier> GetAllSuppliersForPurchaseUser();
        public Task<bool> ToggleActiveStatus(int supplierId);
    }
}
