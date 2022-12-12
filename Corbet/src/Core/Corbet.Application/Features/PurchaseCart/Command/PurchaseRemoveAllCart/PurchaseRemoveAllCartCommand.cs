using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseRemoveAllCart
{
    
    public class PurchaseRemoveAllCartCommand : IRequest<Response<PurchaseRemoveAllCartCommandDto>>
    {
        public int UserId;
    }
}
