using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.CheckPhoneExist
{
    public class CheckPhoneExistCommandHandler : IRequestHandler<CheckPhoneExistCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CheckPhoneExistCommandHandler> _logger;

        public CheckPhoneExistCommandHandler(ILogger<CheckPhoneExistCommandHandler> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(CheckPhoneExistCommand request, CancellationToken cancellationToken)
        {
            var checkPhoneAvailabilityStatus = await _customerRepository.CheckPhoneExists(request.PhoneNumber);
            return (checkPhoneAvailabilityStatus) ? true : false;
        }
    }
}
