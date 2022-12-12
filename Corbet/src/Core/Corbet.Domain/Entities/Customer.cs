using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Common;

namespace Corbet.Domain.Entities
{
    public class Customer: AuditableEntityModel
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(200)]
        public string FirstName { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public int State { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(2000)]
        public string Address { get; set; }
        [MaxLength(2000)]
        public string? AlternateAddress { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }
}
