using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.AddCart.Queries;
using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetAllCart
{
    public class PurchaseGetAllCartQuery : IRequest<List<PurchaseGetAllCartQueryVm>>
    {
        public int userId { get; set; }
        
    }
}
