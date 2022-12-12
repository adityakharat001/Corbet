using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.PurchaseCart.Queries.GetAllOrder;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IPurchaseOrderManagement : IAsyncRepository<PurchaseOrderManagement>
    {
        Task<List<GetAllOrderQueryVm>> GetAllOrder(int UserId);
        List<PurchaseCart> GetAllCart(int userId);

        Task<bool> UpdateStatus(int UserId, string status);
    }
}
