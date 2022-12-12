using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.OrderManagement.Command.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommand : IRequest<Response<CreatePurchaseOrderCommandDto>>
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int SupplierId { get; set; }
        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; } = DateTime.Now;
        public int AddressId { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

    }
}
