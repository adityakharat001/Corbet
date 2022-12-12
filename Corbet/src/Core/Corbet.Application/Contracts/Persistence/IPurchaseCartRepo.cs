using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.PurchaseCart.Command.PurchaseDeleteCart;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseRemoveAllCart;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IPurchaseCartRepo : IAsyncRepository<PurchaseCart>
    {
        Task<bool> IsCartExist(PurchaseCart purchaseCart);
        Task<List<Features.PurchaseCart.Queries.GetAllCart.PurchaseGetAllCartQueryVm>> PurchaseGetAllCart(int userId);
        Task<PurchaseDeleteCartDto> RemovePurchaseCartAsync(int cartId);
        bool IncreaseCartitem(int cartId, int userId, int stockId, int productId, int Quantity);
        bool DecreaseCartitem(int cartId, int userId, int stockId, int productId, int Quantity);
        Task<PurchaseRemoveAllCartCommandDto> RemoveAllCartAsync(int userId);
        bool QuantityUpdate(int cartId, int userId, int stockId, int productId, int Quantity);
    }
}