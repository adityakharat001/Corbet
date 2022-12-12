using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class PurchaseOrderManagement
    {

        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }

        [MaxLength(20)]
        public string OrderCode { get; set; }
        public int SupplierId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; } = "Pending";


        public virtual int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual OrderAddress OrderAddress { get; set; }
    }
}
