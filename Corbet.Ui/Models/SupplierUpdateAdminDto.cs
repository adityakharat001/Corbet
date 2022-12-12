using Corbet.Domain.Common;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class SupplierUpdateAdminDto : AuditableEntityModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Supplier Id is required")]
        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        [DisplayName("Supplier Name")]
        [Remote("CheckSupplierExists", "Supplier")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Special characters are not allowed.")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Credit Limit is required")]
        [Range(500, Int32.MaxValue ,ErrorMessage = "Minimum value must be at least 500")]
        [DisplayName("Credit Limit")]
        public long CreditLimit { get; set; }
        [DisplayName("Payment Status")]
        public bool IsPaymentDone { get; set; }
    }
}
