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

namespace Corbet.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Response<CreateRoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<CreateRoleCommandHandler> _logger;

        public CreateRoleCommandHandler(ILogger<CreateRoleCommandHandler> logger,IMapper mapper, IRoleRepository roleRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<Response<CreateRoleDto>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request);
            var roleData = await _roleRepository.AddAsync(role);
            var roleDto = _mapper.Map<CreateRoleDto>(roleData);
            return new Response<CreateRoleDto>(roleDto);

        }
    }
}
