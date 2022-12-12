using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.PurchaseCart.Command
{
    public class CreatePurchaseCartCommand:IRequest<Response<CreatePurchaseCartDto>>
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }

        public int StockId { get; set; }

        public int Quantity { get; set; }

    }
}
