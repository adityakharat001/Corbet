using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetAllCart
{
    public class PurchaseGetAllCartQueryVm
    {

        public int ProductId { get; set; }
        public int stockId { get; set; }
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
