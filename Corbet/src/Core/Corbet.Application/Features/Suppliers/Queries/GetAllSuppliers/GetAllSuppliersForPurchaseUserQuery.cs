using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersForPurchaseUserQuery : IRequest<List<GetAllSuppliersQueryVm>>
    {
    }
}
