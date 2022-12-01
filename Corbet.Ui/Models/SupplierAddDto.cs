using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Models
{
    public class SupplierAddDto
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
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone")]
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
