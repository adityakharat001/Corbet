using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.PurchaseCart.Command.PurchaseIncrementCart;
using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseQuantityUpdate
{
    public class PurchaseQuantityUpdateCommand : IRequest<PurchaseQuantityUpdateDto>
    {

        public int CartId;
        public int UserId;
        public int stockId;
        public int productId;
        public int Quantity;
    }
}
