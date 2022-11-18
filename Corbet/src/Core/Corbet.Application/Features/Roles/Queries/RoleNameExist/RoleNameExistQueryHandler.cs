using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Roles.Queries.RoleNameExist
{
    public class RoleNameExistQueryHandler : IRequestHandler<RoleNameExistQuery, bool>
    {
        private readonly ILogger<RoleNameExistQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleNameExistQueryHandler(ILogger<RoleNameExistQueryHandler> logger, IMapper mapper, IRoleRepository roleRepository)

        {
            _logger = logger;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public Task<bool> Handle(RoleNameExistQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("roleInitiate");
            Task<bool> check = _roleRepository.CheckRoleExists(request.RoleName);
            return check;
        }

    }




}
