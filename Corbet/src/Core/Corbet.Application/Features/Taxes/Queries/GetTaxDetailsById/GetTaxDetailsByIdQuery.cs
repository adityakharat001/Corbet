using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetTaxDetailsById
{
    public class GetTaxDetailsByIdQuery : IRequest<Response<TaxDetail>>
    {
        public int Id { get; set; }
    }
}
