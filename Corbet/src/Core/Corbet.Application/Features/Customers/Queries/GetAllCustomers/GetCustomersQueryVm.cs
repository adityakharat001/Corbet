using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetCustomersQueryVm
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? AlternateAddress { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }
}
