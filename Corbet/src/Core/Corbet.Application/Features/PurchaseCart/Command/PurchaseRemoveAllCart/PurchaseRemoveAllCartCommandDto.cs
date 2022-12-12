using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseRemoveAllCart
{
    public class PurchaseRemoveAllCartCommandDto
    {

        public string Message { get; set; }
        public int UserId { get; set; }
        public bool Succeeded { get; set; }
    }
}
