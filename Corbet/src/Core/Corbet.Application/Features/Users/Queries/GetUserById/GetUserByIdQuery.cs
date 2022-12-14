using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}
