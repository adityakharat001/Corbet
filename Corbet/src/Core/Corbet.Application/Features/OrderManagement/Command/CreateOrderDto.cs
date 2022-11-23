using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.OrderManagement.Command
{
    public class CreateOrderDto
    {
        public int SupplierId { get; set; }
        public int OrderProductId { get; set; }
        public int Quantity { get; set; }
        public string MailThumb { get; set; }
        public string POThumb { get; set; }


        public string Description { get; set; }
    }
}
