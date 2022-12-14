using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Response<ForgotPasswordDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ForgotPasswordCommandHandler> _logger;
        private readonly IMapper _mapper;

        public ForgotPasswordCommandHandler(ILogger<ForgotPasswordCommandHandler> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<ForgotPasswordDto>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var checkEmailAvailabilityStatus = await _userRepository.CheckEmailExists(request.Email);
            var user = await _userRepository.GetUserByEmail(request.Email);
            var forgotPasswordDto = _mapper.Map<ForgotPasswordDto>(user);
            return (checkEmailAvailabilityStatus) ? new Response<ForgotPasswordDto>() { Data = forgotPasswordDto, Succeeded = checkEmailAvailabilityStatus, Message = $"Email Available - send email to {request.Email}" } :
                new Response<ForgotPasswordDto>() { Data = forgotPasswordDto, Succeeded = checkEmailAvailabilityStatus, Errors = new List<string>() { "Email Not Available!", "Cannot send the email because no user exists with this email address." } };
        }
    }
}