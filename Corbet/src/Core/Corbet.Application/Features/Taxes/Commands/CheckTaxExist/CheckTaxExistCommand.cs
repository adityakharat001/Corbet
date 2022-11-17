using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Commands.CheckTaxExist
{
    public class CheckTaxExistCommand : IRequest<bool>
    {
        public string Name{ get; set; }
        public CheckTaxExistCommand(string tax)
        {
            Name = tax;
        }
    }
}
