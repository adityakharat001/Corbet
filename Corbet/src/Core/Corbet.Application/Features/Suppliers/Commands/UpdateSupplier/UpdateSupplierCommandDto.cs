using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string SupplierType { get; set; }
        public int CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; }
    }
}
