using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.CheckPhoneExist
{
    public class CheckPhoneExistCommand: IRequest<bool>
    {
        public string PhoneNumber { get; set; }
        public CheckPhoneExistCommand(string phone)
        {
            PhoneNumber = phone;
        }
    }
}
