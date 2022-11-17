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

namespace Corbet.Application.Features.Users.Commands.CheckPhoneExist
{
    public class CheckPhoneExistCommandHandler : IRequestHandler<CheckPhoneExistCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CheckPhoneExistCommandHandler> _logger;

        public CheckPhoneExistCommandHandler(ILogger<CheckPhoneExistCommandHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CheckPhoneExistCommand request, CancellationToken cancellationToken)
        {
            var checkPhoneAvailabilityStatus = await _userRepository.CheckPhoneExists(request.PhoneNumber);
            return (checkPhoneAvailabilityStatus) ? true : false;
        }
    }
}
