using Corbet.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Domain.Entities
{
    public class User : AuditableEntityModel
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(200)]
        public string FirstName { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public string Password { get; set; }
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; } = false;
        public int RoleId { get; set; }
        [MaxLength(30)]
        public string? EmailConfirmationCode { get; set; }
        public int? AccessFailedCount { get; set; }
        public bool IsLocked { get; set; } = false;
        public bool IsTwoFactorEnabled { get; set; } = false;
        public DateTime? LockOutEndDateUtc { get; set; }
        public bool IsActive { get; set; } = true;
        public string? SignInToken { get; set; }
        public DateTime? SignInTokenExpireTimeUtc { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
