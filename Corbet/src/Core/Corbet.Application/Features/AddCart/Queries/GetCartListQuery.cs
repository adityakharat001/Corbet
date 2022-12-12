using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.AddCart.Queries
{
    public class GetCartListQuery:IRequest<List<GetCartListVm>>
    {
        public int userId { get; set; }
        

   
    }
}
