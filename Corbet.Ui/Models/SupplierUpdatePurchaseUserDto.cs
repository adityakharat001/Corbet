using Corbet.Domain.Common;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class SupplierUpdatePurchaseUserDto 
    {
        [DisplayName("Supplier Id")]
        public int Id { get; set; }

        [DisplayName("Supplier Name")]
        [Required]
        [Remote("CheckSupplierExists", "Supplier")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Special characters are not allowed.")]
        public string SupplierName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public int PhoneNumber { get; set; }
        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
