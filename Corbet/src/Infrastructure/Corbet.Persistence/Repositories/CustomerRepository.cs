using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Customers.Commands.CreateCustomer;
using Corbet.Application.Features.Customers.Commands.DeleteCustomer;
using Corbet.Application.Features.Customers.Queries.GetAllCustomers;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CustomerRepository(ApplicationDbContext dbContext, ILogger<Customer> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<List<GetCustomersQueryVm>> GetAllCustomers()
        {

            var customerdata = (from s in _dbContext.States
                            join c in _dbContext.Customers
                            on s.StateId equals c.State
                            where c.IsDeleted == false && c.IsActive == true 
                            select new GetCustomersQueryVm
                            {
                                CustomerId = c.CustomerId,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Email = c.Email,
                                PhoneNumber = c.PhoneNumber,
                                State = s.StateName,
                                City = c.City,
                                Address = c.Address,
                                AlternateAddress = c.AlternateAddress,
                                ImagePath = c.ImagePath,
                                IsActive = c.IsActive,
                                IsDeleted = c.IsDeleted

                            }).ToList();

            return customerdata;
        }

        public Task<bool> CheckEmailExists(string Email)
        {
            Customer check = _dbContext.Customers.Where(x => x.Email == Email).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> CheckPhoneExists(string Phone)
        {
            Customer check = _dbContext.Customers.Where(x => x.PhoneNumber == Phone).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }


        public async Task<Customer> FindCustomerByEmail(string email, string password)
        {
            string encPassword = EncryptionDecryption.EncryptString(password);
            Customer user = await _dbContext.Customers.Where(u => u.Email == email && u.Password == encPassword).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            else
            {
                if (!user.IsDeleted && user.IsActive)
                {
                    return user;
                }
                return null;
            }

        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            Customer customer = _dbContext.Customers.Where(u => u.Email == email).FirstOrDefault();
            return customer;
        }

        public async Task<CreateCustomerCommandDto> RegisterCustomerAsync(Customer request)
        {
            var customer = _dbContext.Customers.Where(u => u.Email == request.Email).FirstOrDefault();
            CreateCustomerCommandDto response = new CreateCustomerCommandDto();
            if (customer != null)
            {
                response.Message = "Email id Already Exist.";
                response.Succeeded = false;
                return response;

            }
            await _dbContext.Customers.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            response.Email = request.Email;
            response.FirstName = request.FirstName;
            response.LastName = request.LastName;
            response.Password = request.Password;
            response.PhoneNumber = request.PhoneNumber;
            response.Succeeded = true;
            response.Message = "Customer registered successfully.";
            return response;
        }

        public async Task<DeleteCustomerCommandDto> RemoveCustomerAsync(int customerId)
        {
            _logger.LogInformation("In Repository Remove Customer Initiated");
            DeleteCustomerCommandDto response = new DeleteCustomerCommandDto();
            var IsCustomerExist = await _dbContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            if (IsCustomerExist != null)
            {
                IsCustomerExist.DeletedDate= DateTime.Now;
                IsCustomerExist.IsDeleted = true;
                IsCustomerExist.IsActive = false;
                await _dbContext.SaveChangesAsync();

                response.Email = IsCustomerExist.Email;
                response.FirstName = IsCustomerExist.FirstName;
                response.Message = "Customer Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove Customer Completed");
            }

            else
            {
                response.Email = null;
                response.FirstName = null;
                response.Message = "Customer with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove Customer Doesn't exist");
            }

        }
    }
}
