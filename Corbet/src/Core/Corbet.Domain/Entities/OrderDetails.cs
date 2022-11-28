using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public virtual  int OrderId { get; set; }

        public virtual int ProductId { get; set; }
         
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int? InvoiceId { get; set; }
    }
}
