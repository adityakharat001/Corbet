using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.UserEmailExist
{
    public class UserEmailExistCommandHandler : IRequestHandler<UserEmailExistCommand, bool>
    {
        private readonly ILogger<UserEmailExistCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserEmailExistCommandHandler(ILogger<UserEmailExistCommandHandler> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public Task<bool> Handle(UserEmailExistCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("mailInitiate");
            Task<bool> check = _userRepository.CheckEmailExists(request.Email);
            return check;
        }
    }
}
