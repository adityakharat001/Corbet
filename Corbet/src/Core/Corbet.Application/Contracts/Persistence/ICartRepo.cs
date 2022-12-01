using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.AddCart.Queries.GetProductSupplier;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ICartRepo : IAsyncRepository<AddToCart>
    {
        Task<DeleteCartCommandDto> RemoveCartAsync(int cartId);
        Task<bool> IsCartExist(AddToCart addToCart);
        Task<List<GetCartListVm>> GetAllCart(int userId);
        Task<List<GetProductSupplierQueryVm>> GetAllProductSupplier();
        bool DecreaseCartitem(int cartId, int userId, int stockId, int productId, int Quantity);
    }
}
