using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryVm
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public long CreaditLimit { get; set; }
        public bool PaymentStatus { get; set; } = true;
    }
}
