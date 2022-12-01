using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.Invoice.Queries.GetAllInvoice
{
    public class GetAllInvoiceQuery:IRequest<List<GetAllInvoiceQueryVm>>
    {

    }
}
