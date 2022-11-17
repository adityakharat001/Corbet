using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.DeleteTaxType
{
    public class DeleteTaxTypeDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
