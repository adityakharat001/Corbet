using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.AddCart.Command.DecreaseCartItem
{
    public class DecreaseCartItemCommand : IRequest<DecreaseCartItemCommandDto>
    {
        public int CartId;
        public int UserId;
        public int stockId;
        public int productId;
        public int Quantity;
    }
}
