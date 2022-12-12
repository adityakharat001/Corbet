using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.OrderManagement.Command.UpdatePurchaseOrder
{
    public class UpdatePurchaseOrderStatusCommand : IRequest<Response<UpdatePurchaseOrderCommandDto>>
    {
        public int UserId { get; set; }
        // public int OrderId { get; set; }    
        public string Status { get; set; }
    }
}
