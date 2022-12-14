using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.UpdateTax
{
    public class UpdateTaxDto
    {
        public int TaxId { get; set; }
        public string Name { get; set; }
    }
}
