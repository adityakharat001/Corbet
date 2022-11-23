using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.SuppliersDetails.Queries.GetAllSupplierDetails
{
    public class GetAllSupplierDetailsQuery:IRequest<List<GetAllSupplierDetailsQueryVm>>
    {
    }
}
