using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.SuppliersDetails.Queries.GetAllSupplierDetails
{
    public class GetAllSupplierDetailsQueryVm
    {
        public int SupplierId { get; set; }
        //company name=supplierName
        public string SupplierName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [MaxLength(300)]
        public string BillingAddress { get; set; }
        [MaxLength(200)]
        public string SupplierType { get; set; }
        public long CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; } = DateTime.Now;
        public string? DocumentPath { get; set; } = "rinku.pdf";

    }
}
