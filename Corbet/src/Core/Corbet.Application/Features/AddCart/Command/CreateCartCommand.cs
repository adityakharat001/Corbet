using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.AddCart.Command
{
    public class CreateCartCommand:IRequest<Response<CreateCartCommandDto>>
    {
       // public int CartId { get; set; }
        public int UserId { get; set; }
        public virtual int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
