using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.CreateTax
{
    public class CreateTaxCommand: IRequest<CreateTaxDto>
    {
        public string Name { get; set; }

    }
}
