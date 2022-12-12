using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseDecrementCart
{

    public class PurchaseDecrementCartCommand : IRequest<PurchaseDecrementCartDto>
    {
        public int CartId;
        public int UserId;
        public int stockId;
        public int productId;
        public int Quantity;
    }
}

