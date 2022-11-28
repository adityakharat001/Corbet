using System;

namespace Corbet.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string RoleName { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
