using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.OrderManagement.Command.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommandDto
    {
        public int OrderId { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
