using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.Invoice.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery:IRequest<Domain.Entities.Invoice>
    {
        public int Id { get; set; }
    }
}
