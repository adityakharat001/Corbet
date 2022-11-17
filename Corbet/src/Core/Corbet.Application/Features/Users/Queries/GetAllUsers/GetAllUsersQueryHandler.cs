using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetUsersQueryVm>>
    {
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<GetUsersQueryVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Users list Initiated");
            var userList = await _userRepository.GetAllUsers();

            // all employee data and Vm datat match or not
            var userData = _mapper.Map<List<GetUsersQueryVm>>(userList);

            _logger.LogInformation("Users list completed");

            return new List<GetUsersQueryVm>(userData);
        }
    }
}
