using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandDto
    {
        public string Message { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public bool Succeeded { get; set; }
    }
}
