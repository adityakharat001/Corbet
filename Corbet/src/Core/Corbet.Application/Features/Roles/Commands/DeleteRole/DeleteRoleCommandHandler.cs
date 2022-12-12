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

namespace Corbet.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler: IRequestHandler<DeleteRoleCommand, Response<DeleteRoleCommandDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<DeleteRoleCommandHandler> _logger;


        public DeleteRoleCommandHandler(IRoleRepository roleRepository, ILogger<DeleteRoleCommandHandler> logger)
        {
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public async Task<Response<DeleteRoleCommandDto>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Role Initiated");
            var roleDto = await _roleRepository.RemoveRoleAsync(request.RoleId, request.DeletedBy);
            _logger.LogInformation("Delete Role Completed");
            if (roleDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteRoleCommandDto>(roleDto, "Success");
            }
            else
            {
                var res = new Response<DeleteRoleCommandDto>(roleDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
            //----------------------------------------------------------------
            //var roleToDelete = await _roleRepository.GetById(request.RoleId);

            //if (roleToDelete == null)
            //{
            //    throw new NotFoundException(nameof(Role), request.RoleId);
            //}

            //await _roleRepository.DeleteAsync(roleToDelete);
            //return Unit.Value;
        }
    }
}
