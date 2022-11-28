using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.AddCart.Command.DeleteCart
{
    public class DeleteCartCommand:IRequest<Response<DeleteCartCommandDto>>
    {
        public int CartId { get; set; } 
       

       
    }

}
