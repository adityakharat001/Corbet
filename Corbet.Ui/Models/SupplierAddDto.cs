using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Corbet.Domain.Common;

using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Models
{
    public class SupplierAddDto:AuditableEntityModel
    {
        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }
        [Required]
        [DisplayName("Supplier Name")]
        [Remote("CheckSupplierExists", "Supplier")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Special characters are not allowed.")]
        public string SupplierName { get; set; }
        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Email Address")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Please Enter A Valid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; }
        [Required]
        public string SupplierType { get; set; }
        [Required]
        [DisplayName("Credit Limit")]
        public long CreditLimit { get; set; }
        [Required]
        [DisplayName("Credit Period")]
        public DateTime CreditPeriod { get; set; }
        public IFormFile? Document { get; set; }
        public string? DocumentPath { get; set; }

    }
}
