using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.AddCart.Queries.GetProductSupplier
{
    public class GetProductSupplierListQuery:IRequest<List<GetProductSupplierQueryVm>>
    {
    }
}
