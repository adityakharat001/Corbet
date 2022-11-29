using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class AddToCart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public virtual int ProductId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
    }
}
