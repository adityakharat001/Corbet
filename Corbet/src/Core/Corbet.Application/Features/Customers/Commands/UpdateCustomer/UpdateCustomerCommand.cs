﻿using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Response<UpdateCustomerCommandDto>>
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? AlternateAddress { get; set; }
        public string? ImagePath { get; set; }
    }
}