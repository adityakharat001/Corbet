using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Queries.GetAllUsers
{
    public class GetUsersQueryVm
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public string? ResetPasswordCode { get; set; }
        public string? EmailConfirmationCode { get; set; }
        public string Role { get; set; }
        public int? AccessFailedCount { get; set; }
        public string? AuthenticationSource { get; set; }
        public bool IsLockoutEnabled { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public DateTime? LockOutEndDateUtc { get; set; }
        public bool IsActive { get; set; }
        public string? ProfilePictureId { get; set; }
        public string? SecurityStamp { get; set; }
        public bool ShouldChangePasswordOnLogin { get; set; }
        public string? SignInToken { get; set; }
        public DateTime? SignInTokenExpireTimeUtc { get; set; }
        public string? GoogleAuthenticatorkey { get; set; }
        public bool IsDeleted { get; set; }

    }
}
