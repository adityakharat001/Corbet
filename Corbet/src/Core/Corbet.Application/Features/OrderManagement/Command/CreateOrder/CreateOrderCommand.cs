using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;

namespace Corbet.Application.Features.OrderManagement.Command.CreateOrder
{
    public class CreateOrderCommand: IRequest<Response<CreateOrderCommandDto>>
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public  int SupplierId { get; set; }
        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string Address { get; set; }

       
    }
}
