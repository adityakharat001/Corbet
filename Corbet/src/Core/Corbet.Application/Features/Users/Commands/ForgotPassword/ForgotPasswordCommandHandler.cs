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

namespace Corbet.Application.Features.Users.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Response<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ForgotPasswordCommandHandler> _logger;

        public ForgotPasswordCommandHandler(ILogger<ForgotPasswordCommandHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task<Response<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var checkEmailAvailabilityStatus = await _userRepository.CheckEmailExists(request.Email);
            return (checkEmailAvailabilityStatus) ? new Response<string>() { Data = request.Email, Succeeded = checkEmailAvailabilityStatus, Message = $"Email Available - send email to {request.Email}" } :
                new Response<string>() { Data = request.Email, Succeeded = checkEmailAvailabilityStatus, Errors = new List<string>() { "Email Not Available!", "Cannot send the email because no user exists with this email address." } };
        }
    }
}