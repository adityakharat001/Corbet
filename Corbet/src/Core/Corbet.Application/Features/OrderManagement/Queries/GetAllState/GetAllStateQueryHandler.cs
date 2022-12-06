using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Roles.Queries.GetAllRoles;
using MediatR;

namespace Corbet.Application.Features.OrderManagement.Queries.GetAllState
{
   
    public class GetAllStateQueryHandler : IRequestHandler<GetAllStateQuery, List<GetAllStateQueryVm>>
    {
        private readonly IStateRepo _stateRepository;
        private readonly IMapper _mapper;

        public GetAllStateQueryHandler(IStateRepo stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllStateQueryVm>> Handle(GetAllStateQuery request, CancellationToken cancellationToken)
        {
            var allState = await _stateRepository.ListAllAsync();
            var AllList = _mapper.Map<List<GetAllStateQueryVm>>(allState);
            //var response = new IEnumerable<GetRolesListVm>(roleList);
            return AllList;
        }
    }
}
