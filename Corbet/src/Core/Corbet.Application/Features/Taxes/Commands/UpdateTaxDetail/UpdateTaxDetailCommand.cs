using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail
{
    public class UpdateTaxDetailCommand : IRequest<Response<UpdateTaxDetailDto>>
    {
        public int Id { get; set; }
        public int TaxId { get; set; }
        public double MinTax { get; set; }
        public double MaxTax { get; set; }
        public double Percentage { get; set; }
        public int? LastModifiedBy { get; set; }

    }
}
