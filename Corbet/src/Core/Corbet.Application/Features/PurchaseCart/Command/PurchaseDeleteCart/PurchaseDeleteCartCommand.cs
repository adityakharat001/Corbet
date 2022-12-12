using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseDeleteCart
{
    
    public class PurchaseDeleteCartCommand : IRequest<Response<PurchaseDeleteCartDto>>
    {
        public int CartId { get; set; }



    }
}
