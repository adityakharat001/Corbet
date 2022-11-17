using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetUsersQueryVm>>
    {
    }
}
