using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ICartRepo : IAsyncRepository<AddToCart>
    {
        Task<DeleteCartCommandDto> RemoveCartAsync(int cartId);
        Task<bool> IsCartExist(AddToCart addToCart);
    }
}
