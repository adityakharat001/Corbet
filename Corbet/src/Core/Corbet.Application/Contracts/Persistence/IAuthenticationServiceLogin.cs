using Corbet.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IAuthenticationServiceLogin
    {
        Task<AuthenticationResponse> Login(string email, string password);
    }
}
