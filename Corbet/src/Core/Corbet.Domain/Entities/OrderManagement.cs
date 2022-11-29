using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class OrderManagement:AuditableEntityModel
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public virtual int SupplierId { get; set; }
        [MaxLength(100)]
        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Suppliers { get; set; }
    }
}
