using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.AddCart.Queries.GetProductSupplier
{
    public class GetProductSupplierQueryVm
    {
        public int StockId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public string ProductCode { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
    }
}
