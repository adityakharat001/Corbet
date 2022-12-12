using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.AddCart.Command.DeleteCart
{
    public class DeleteCartCommandDto
    {
        public string Message { get; set; }
        public int CartId { get; set; }
        public bool Succeeded { get; set; }
    }
}
