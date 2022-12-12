﻿using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Response<CreateUserCommandDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CreatedBy { get; set; }


    }
}
