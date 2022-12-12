using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetAllOrder
{
    public class GetAllOrderQuery:IRequest<List<GetAllOrderQueryVm>>
    {
        public int UserId { get; set; }
    }
}
