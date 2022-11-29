using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public virtual int OrderId { get; set; }
        public int StockId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderManagement OrderManagement { get; set; }

    }
}
