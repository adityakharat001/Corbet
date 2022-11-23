using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Corbet.Domain.Common;

namespace Corbet.Ui.Models
{
    public class SupplierDetailsViewModel:AuditableEntityModel
    {
        [Key]
        public int SupplierId { get; set; }
        [DisplayName("Supplier Name")]
        [Required(ErrorMessage ="Enter Supplier Name")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Supplier Name should contain only alphabets")]
        [MaxLength(150)]
        //company name=supplierName
        public string SupplierName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage ="Enter Email Address")]
        [MaxLength(150)]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        [Required(ErrorMessage ="Enter Phone Number")]
      
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [DisplayName("Billing Address")]
        [Required(ErrorMessage = "Enter Billing Address")]
        [MaxLength(300)]
        public string BillingAddress { get; set; }
        [DisplayName("Supplier Type")]
        [Required(ErrorMessage = "Enter Supplier Type")]
        [MaxLength(200)]
        public string SupplierType { get; set; }
        [DisplayName("Credit Limit")]
        [Required(ErrorMessage ="Enter Credit Limit")]
        public long CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; } = DateTime.Now;
        public string? DocumentPath { get; set; } = "rinku.pdf";
        public bool IsDeleted { get; set; }
    }
}
