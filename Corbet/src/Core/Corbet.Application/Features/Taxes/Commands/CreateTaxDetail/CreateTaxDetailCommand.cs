using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.CreateTaxDetail
{
    public class CreateTaxDetailCommand : IRequest<Response<CreateTaxDetailDto>>
    {
        public int TaxId { get; set; }
        public double MinTax { get; set; }
        public double MaxTax { get; set; }
        public double Percentage { get; set; }
        public bool Status { get; set; } = false;
        public int? CreatedBy { get; set; }
    }
}
