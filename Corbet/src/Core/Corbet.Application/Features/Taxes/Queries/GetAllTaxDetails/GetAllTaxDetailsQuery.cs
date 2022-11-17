using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails
{
    public class GetAllTaxDetailsQuery: IRequest<List<GetTaxDetailListVm>>
    {

    }
}
