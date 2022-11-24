using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.SuppliersDetails.Command.DeleteSupplierDetails
{
    public class DeleteSupplierDetailsCommandDto
    {
        //public string Email { get; set; }
        //public string SupplierName { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
