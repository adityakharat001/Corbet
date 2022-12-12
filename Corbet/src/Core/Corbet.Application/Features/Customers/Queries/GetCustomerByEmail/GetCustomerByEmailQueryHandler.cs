using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Queries.GetCustomerByEmail
{
    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByEmailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            Customer user = await _customerRepository.GetCustomerByEmail(request.Email);
            return user;
        }
    }
}
