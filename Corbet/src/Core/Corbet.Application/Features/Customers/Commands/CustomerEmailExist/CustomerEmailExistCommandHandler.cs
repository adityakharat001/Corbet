using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.CustomerEmailExist
{
    public class CustomerEmailExistCommandHandler : IRequestHandler<CustomerEmailExistCommand, bool>
    {
        private readonly ILogger<CustomerEmailExistCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerEmailExistCommandHandler(ILogger<CustomerEmailExistCommandHandler> logger, IMapper mapper, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public Task<bool> Handle(CustomerEmailExistCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("mailInitiate");
            Task<bool> check = _customerRepository.CheckEmailExists(request.Email);
            return check;
        }
    }
}
