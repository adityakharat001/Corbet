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

namespace Corbet.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<DeleteUserCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IMapper mapper, ILogger<DeleteUserCommandHandler> logger, IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Response<DeleteUserCommandDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Delete User Initiated");
            var userDto = await _userRepository.RemoveUserAsync(request.UserId);
            _logger.LogInformation("Delete User Completed");
            if (userDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteUserCommandDto>(userDto, "Success");
            }
            else
            {
                var res = new Response<DeleteUserCommandDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
        }
    }
}
