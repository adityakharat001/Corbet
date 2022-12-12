using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetAllOrder
{
    public class GetAllOrderQueryVm
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }    
        public string OrderCode { get; set; }
        public string Status { get; set; }
        public string SupplierName { get; set; }
    }
}
