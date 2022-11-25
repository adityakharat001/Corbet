using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Corbet.Domain.Common;

namespace Corbet.Ui.Models
{
    public class SupplierViewModel:AuditableEntityModel
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Supplier Name is required")]
        [DisplayName("Supplier Name")]
        [RegularExpression(@"^([A-Za-z])+( [A-Za-z]+)*$", ErrorMessage = " Supplier Name must contain only alphabet")]
        [MaxLength(100)]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Credit Limit is required")]
        [Range(500, Int32.MaxValue, ErrorMessage = "Minimum value must be at least 500")]
        [DisplayName("Credit Limit")]
        public long CreaditLimit { get; set; }
        [DisplayName("Payment Status")]
        public bool PaymentStatus { get; set; } = true;
    }
}
