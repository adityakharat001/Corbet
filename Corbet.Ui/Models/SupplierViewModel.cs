using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class SupplierViewModel
    {
        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }
        [DisplayName("Supplier Name")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Supplier Name must contain only alphabet")]
        [MaxLength(100)]
        public string SupplierName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }
        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; }
        public string SupplierType { get; set; }
        [DisplayName("Credit Limit")]
        public long CreditLimit { get; set; }
        [DisplayName("Credit Period")]
        public DateTime CreditPeriod { get; set; }
        public string? DocumentPath { get; set; }
        [DisplayName("Creation Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Payment Status")]
        public bool IsPaymentDone { get; set; }
        [DisplayName("Active Status")]
        public bool IsActive { get; set; }
        [DisplayName("Delted Status")]
        public bool IsDeleted { get; set; }
    }
}
