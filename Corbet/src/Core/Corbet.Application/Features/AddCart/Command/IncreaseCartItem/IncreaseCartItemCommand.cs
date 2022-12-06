using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.AddCart.Command.DecreaseCartItem
{
    public class IncreaseCartItemCommand:IRequest<IncreaseCartItemCommandDto>
    {

        
        public int CartId;
        public int UserId;
       public int stockId;
       public int productId;
        public int Quantity;
        //public DecreaseCartItemCommand(int cartId, int userId, int stockId, int productId, int quantity)
        //{
        //    CartId = cartId;
        //    UserId = userId;
        //    this.stockId = stockId;
        //    this.productId = productId;
        //    Quantity = quantity;
        //}   
    }
}
