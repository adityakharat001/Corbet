using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Queries.GetCustomerByEmail
{
    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string Email { get; set; }
    }
}
