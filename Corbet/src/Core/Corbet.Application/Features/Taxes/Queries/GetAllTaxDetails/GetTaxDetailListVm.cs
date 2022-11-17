using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails
{
    public class GetTaxDetailListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MinTax { get; set; }
        public double MaxTax { get; set; }
        public double Percentage { get; set; }
        public bool Status { get; set; }
        [ForeignKey("TaxId")]
        public virtual Tax Taxes { get; set; }
    }
}
