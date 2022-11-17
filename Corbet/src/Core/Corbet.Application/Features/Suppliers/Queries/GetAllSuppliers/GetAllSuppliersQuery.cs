using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<List<GetAllSuppliersQueryVm>>
    {
    }
}
