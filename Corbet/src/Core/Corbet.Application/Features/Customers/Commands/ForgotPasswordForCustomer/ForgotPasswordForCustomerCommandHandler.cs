using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.ForgotPasswordForCustomer
{
    public class ForgotPasswordForCustomerCommandHandler : IRequestHandler<ForgotPasswordForCustomerCommand, Response<string>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<ForgotPasswordForCustomerCommandHandler> _logger;

        public ForgotPasswordForCustomerCommandHandler(ILogger<ForgotPasswordForCustomerCommandHandler> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        public async Task<Response<string>> Handle(ForgotPasswordForCustomerCommand request, CancellationToken cancellationToken)
        {
            var checkEmailAvailabilityStatus = await _customerRepository.CheckEmailExists(request.Email);
            return (checkEmailAvailabilityStatus) ? new Response<string>() { Data = request.Email, Succeeded = checkEmailAvailabilityStatus, Message = $"Email Available - send email to {request.Email}" } :
                new Response<string>() { Data = request.Email, Succeeded = checkEmailAvailabilityStatus, Errors = new List<string>() { "Email Not Available!", "Cannot send the email because no user exists with this email address." } };
        }
    }
}