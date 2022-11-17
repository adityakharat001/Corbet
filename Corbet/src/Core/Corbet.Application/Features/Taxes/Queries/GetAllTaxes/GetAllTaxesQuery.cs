using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetAllTaxes
{
    public class GetAllTaxesQuery: IRequest<List<GetAllTaxesVm>>
    {
    }
}
