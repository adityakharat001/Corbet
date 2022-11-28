using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.AddCart.Command.CreateCart
{
    public class CreateCartCommandDto
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public virtual int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
