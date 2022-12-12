using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseDeleteCart
{
    public class PurchaseDeleteCartDto
    {
        public string Message { get; set; }
        public int CartId { get; set; }
        public bool Succeeded { get; set; }
    }
}
