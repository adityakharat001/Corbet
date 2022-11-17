using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, List<GetRolesListVm>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRolesListQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<GetRolesListVm>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var allRoles = await _roleRepository.GetAllRoles();
            var roleList = _mapper.Map<List<GetRolesListVm>>(allRoles);
            //var response = new IEnumerable<GetRolesListVm>(roleList);
            return roleList;
        }
    }
}
