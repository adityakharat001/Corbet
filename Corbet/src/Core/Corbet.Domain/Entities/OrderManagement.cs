using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class OrderManagement 
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public   int SupplierId { get; set; }
        public virtual  int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public string MailThumb { get; set; }
        public string POThumb { get; set; }


        public string Description { get; set; }


        public bool IsDeleted { get; set; } = false;
 
        [ForeignKey("OrderProductId")]
        public virtual Product Products { get; set; }






    }
}
