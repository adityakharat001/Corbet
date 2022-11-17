using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetRolesListQuery : IRequest<List<GetRolesListVm>>
    {
    }
}
