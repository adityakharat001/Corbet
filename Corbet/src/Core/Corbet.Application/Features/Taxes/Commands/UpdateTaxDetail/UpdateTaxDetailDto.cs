using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail
{
    public class UpdateTaxDetailDto
    {
        public int Id { get; set; }
        public int TaxId { get; set; }
        public double MinTax { get; set; }
        public double MaxTax { get; set; }
        public double Percentage { get; set; }
        public bool Status { get; set; }
    }
}
