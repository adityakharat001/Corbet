using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetTaxById
{
    public class GetTaxByIdQuery: IRequest<Response<Tax>>
    {
        public int TaxId { get; set; }
    }
}
