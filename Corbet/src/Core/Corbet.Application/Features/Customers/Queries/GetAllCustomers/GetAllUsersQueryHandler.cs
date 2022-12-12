using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<GetCustomersQueryVm>>
    {
        private readonly ILogger<GetAllCustomersQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ILogger<GetAllCustomersQueryHandler> logger, IMapper mapper, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<GetCustomersQueryVm>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Customers list Initiated");
            var userList = await _customerRepository.GetAllCustomers();

            // all employee data and Vm datat match or not
            var userData = _mapper.Map<List<GetCustomersQueryVm>>(userList);

            _logger.LogInformation("Customers list completed");

            return new List<GetCustomersQueryVm>(userData);
        }
    }
}
