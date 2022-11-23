using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.OrderManagement.Queries
{
    public class GetOrderListVm
    {
     public string SupplierName { get; set; }

      public string DeliveryAddress { get; set; }
       // public DateOnly DeliveryDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Double Price { get; set; }

       public DateTime CreditLimit { get; set; }
        public string ThumbNail { get; set; }
        public string POThumb { get; set; }
        public string Description { get; set; }


    }
}
