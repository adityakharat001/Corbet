using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.Customers.Commands.CreateCustomer;
using Corbet.Application.Features.Customers.Commands.DeleteCustomer;
using Corbet.Application.Features.Customers.Queries.GetAllCustomers;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {

        public Task<Customer> GetCustomerByEmail(string email);
        public Task<Customer> FindCustomerByEmail(string email, string Password);
        public Task<CreateCustomerCommandDto> RegisterCustomerAsync(Customer user);
        public Task<bool> CheckEmailExists(string email);
        public Task<bool> CheckPhoneExists(string phone);
        public Task<List<GetCustomersQueryVm>> GetAllCustomers();
        public Task<DeleteCustomerCommandDto> RemoveCustomerAsync(int userId);
    }
}
