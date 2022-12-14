using Corbet.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class TaxDetailsViewModel : AuditableEntityModel
    {
        public string? Id { get; set; }
        public int TaxDetailsId { get; set; }
        [Required(ErrorMessage = "Please Enter TaxType")]
        [DisplayName("Tax Type")]
        public int TaxId { get; set; }
        [DisplayName("Min Tax ")]
        [RegularExpression(@"^([+]?\d*\.?\d{0,9})$", ErrorMessage = "Invalid Min Tax")]
        public double MinTax { get; set; }
        [DisplayName("Max Tax ")]
        [RegularExpression(@"^([+]?\d*\.?\d{0,9})$", ErrorMessage = "Invalid Max Tax")]
        public double MaxTax { get; set; }
        [RegularExpression(@"^([+]?\d*\.?\d{0,9})$", ErrorMessage = "Invalid Percentage")]
        [Required(ErrorMessage = "Percentage is required")]
        [Range(0, 100, ErrorMessage = "Percentage should be between 0 to 100")]
        [DisplayName("Percentage")]
        public double Percentage { get; set; }
        [Required(ErrorMessage = "Choose Status for Tax Details")]
        [DisplayName("Active Status")]
        public bool Status { get; set; }
    }
}
