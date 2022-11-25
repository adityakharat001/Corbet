using Corbet.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class TaxDetailsViewModel : AuditableEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter TaxType")]
        public int TaxId { get; set; }
        [DisplayName("Min Tax ")]
        [RegularExpression(@"^([+]?\d*\.?\d{0,9})$", ErrorMessage = "Invalid Min Tax")]
        public double MinTax { get; set; }
        [DisplayName("Max Tax ")]
        [RegularExpression(@"^([+]?\d*\.?\d{0,9})$", ErrorMessage = "Invalid Max Tax")]
        public double MaxTax { get; set; }
        [RegularExpression(@"^([+]?\d*\.?\d{0,9})$", ErrorMessage = "Invalid Percentage")]
        [Required(ErrorMessage = "Percentage is required")]
        [DisplayName("Percentage")]
        public double Percentage { get; set; }
        [Required(ErrorMessage = "Choose Status for Tax Details")]
        [DisplayName("Active Status")]
        public bool Status { get; set; }
    }
}
