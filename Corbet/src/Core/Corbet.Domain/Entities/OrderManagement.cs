using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public  class OrderManagement
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public string OrderCode { get; set; }
        public DateTime DeliveryDate { get; set; }

        public string Address { get; set; }

       
    }
}
