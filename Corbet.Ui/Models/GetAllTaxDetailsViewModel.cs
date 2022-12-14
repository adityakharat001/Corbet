using Corbet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corbet.Ui.Models
{
    public class GetAllTaxDetailsViewModel
    {
        public string? TaxDetailsId { get; set; }
        public string Name { get; set; }
        public double MinTax { get; set; }
        public double MaxTax { get; set; }
        public double Percentage { get; set; }
        public bool Status { get; set; }
        [ForeignKey("TaxId")]
        public virtual Tax Taxes { get; set; }
    }
}
