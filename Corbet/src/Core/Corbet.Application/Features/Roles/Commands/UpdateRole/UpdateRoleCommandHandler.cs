using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Exceptions;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<UpdateRoleCommandDto>>
    {
        private readonly ILogger<UpdateRoleCommandHandler> _logger;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UpdateRoleCommandHandler(ILogger<UpdateRoleCommandHandler> logger, IRoleRepository roleRepository, IMapper mapper)
        {
            _logger = logger;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<Response<UpdateRoleCommandDto>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update Role initiated");
            var role = await _roleRepository.GetById(request.RoleId);
            if (role == null)
            {
                throw new NotFoundException(nameof(Role), request.RoleId);
            }

            var roleData = _mapper.Map(request, role);
            await _roleRepository.UpdateAsync(roleData);
            var roleDto = _mapper.Map<UpdateRoleCommandDto>(roleData);
            _logger.LogInformation("Update Employee completed");
            return new Response<UpdateRoleCommandDto>(roleDto);
        }
    }
}
