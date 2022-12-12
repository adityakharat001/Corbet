using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Models.Authentication;
using Corbet.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Persistence.Services
{
    public class AuthenticationServiceLogin : IAuthenticationServiceLogin
    {

        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationServiceLogin> _logger;

        public AuthenticationServiceLogin(IConfiguration configuration, IUserRepository userRepository, ILogger<AuthenticationServiceLogin> logger, IRoleRepository roleRepository, ICustomerRepository customerRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _customerRepository = customerRepository;
        }
        public async Task<AuthenticationResponse> Login(string email, string password)
        {
            User user = await _userRepository.FindUserByEmail(email, password);
            if (user == null)
            {
                throw new Exception("Failed to find user with these credentials");
            }
            else
            {
                Role roleOfUser = await _roleRepository.GetById(user.RoleId);
                string roleName = roleOfUser.RoleName;
                int userId = user.UserId;
                string name = $"{user.FirstName} {user.LastName}";
                string token = GenerateToken(user.UserId, user.Email, name);
                return new AuthenticationResponse() { IsAuthenticated = true, Token = token, Message = "Login Successful", UserName = name, Id = userId ,RoleName = roleName};

            }
        }
        
        public async Task<AuthenticationResponse> LoginCustomer(string email, string password)
        {
            Customer user = await _customerRepository.FindCustomerByEmail(email, password);
            if (user == null)
            {
                throw new Exception("Failed to find user with these credentials");
            }
            else
            {
                int customerId = user.CustomerId;
                string name = $"{user.FirstName} {user.LastName}";
                string token = GenerateToken(user.CustomerId, user.Email, name);
                string roleName = "customer";
                return new AuthenticationResponse() { IsAuthenticated = true, Token = token, Message = "Login Successful", UserName = name, Id = customerId, RoleName = roleName};

            }
        }

        //@Author : Kajol Pathak
        //Method for setting claims and JWT Token generation 
        public string GenerateToken(int id, string email, string name)
        {

            _logger.LogInformation("Generated Token  Initiated");
            var Userclaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,name)
            };
            var userSecurityKey = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);
            var userSymmetricSecurity = new SymmetricSecurityKey(userSecurityKey);
            var JwtValidity = _configuration.GetValue<string>("JwtSettings:DurationInMinutes");
            var userSiginCreditional = new SigningCredentials(userSymmetricSecurity, SecurityAlgorithms.HmacSha256Signature);
            var userJwtSecurityToken = new JwtSecurityToken

                (
                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Audience"],
                    claims: Userclaims,
                        expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(JwtValidity)),
                    signingCredentials: userSiginCreditional


                );
            var userSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken);
            string userjwttoken = JsonConvert.SerializeObject(new { Token = userSecurityTokenHandler, name });
            return userjwttoken;
        }
    }
}
