using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.AddCart.Command.RemoveAllCart
{
    public class RemoveAllCartCommand:IRequest<Response<RemoveAllCartCommandDto>>
    {
       public int UserId;
    }
}
