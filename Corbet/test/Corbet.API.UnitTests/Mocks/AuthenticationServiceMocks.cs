using Corbet.Application.Contracts.Identity;
using Corbet.Application.Models.Authentication;
using Moq;
using System;

namespace Corbet.API.UnitTests.Mocks
{
    public class AuthenticationServiceMocks
    {
        public static Mock<IAuthenticationService> GetAuthenticationService()
        {
            var mockAuthenticationService = new Mock<IAuthenticationService>();

            mockAuthenticationService.Setup(auth => auth.AuthenticateAsync(It.IsAny<AuthenticationRequest>())).ReturnsAsync(new AuthenticationResponse() 
            {
                Message = "Message",
                IsAuthenticated = true,
                UserName = "UserName",
                Email = "Email",
                Token = "Token",
                RefreshToken = "RefreshToken",
                RefreshTokenExpiration = DateTime.Now
            });
            mockAuthenticationService.Setup(auth => auth.RegisterAsync(It.IsAny<RegistrationRequest>())).ReturnsAsync(new RegistrationResponse()
            {
                UserId = "UserId"
            });
            mockAuthenticationService.Setup(auth => auth.RefreshTokenAsync(It.IsAny<RefreshTokenRequest>())).ReturnsAsync(new RefreshTokenResponse()
            {
                Message = "Message",
                IsAuthenticated = true,
                UserName = "UserName",
                Email = "Email",
                Token = "Token",
                RefreshToken = "RefreshToken",
                RefreshTokenExpiration = DateTime.Now
            });

            return mockAuthenticationService;
        }
    }
}
