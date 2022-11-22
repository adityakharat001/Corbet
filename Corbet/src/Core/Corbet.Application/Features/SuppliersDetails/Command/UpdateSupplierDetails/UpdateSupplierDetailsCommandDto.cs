using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.SuppliersDetails.Command.UpdateSupplierDetails
{
    public class UpdateSupplierDetailsCommandDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int CreditLimit { get; set; }
        public bool IsPaymentDone { get; set; }
    }
}
