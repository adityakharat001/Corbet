using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class Stock : AuditableEntityModel
    {
        public int StockId { get; set; }

        public virtual int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual int StockTypeId { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }

        [ForeignKey("StockTypeId")]
        public virtual StockType StockTypes { get; set; }
    }
}
