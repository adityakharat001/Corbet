using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.OrderManagement.Queries.GetAllState
{
    public class GetAllStateQuery: IRequest<List<GetAllStateQueryVm>>
    { 
    }
}
