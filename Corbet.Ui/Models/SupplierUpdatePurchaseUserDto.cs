using Corbet.Domain.Common;
using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class SupplierUpdatePurchaseUserDto : AuditableEntity
    {
        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }

        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }
    }
}
