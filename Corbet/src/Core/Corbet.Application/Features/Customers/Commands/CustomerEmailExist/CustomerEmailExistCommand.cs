using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.CustomerEmailExist
{
    public class CustomerEmailExistCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
