using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommand : IRequest<Response<UpdateTaxDto>>
    {
        public int TaxId { get; set; }
        public string Name { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
