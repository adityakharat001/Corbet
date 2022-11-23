using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommand:IRequest<Response<CreateSupplierCommandDto>>
    {
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string SupplierType { get; set; }
        public long CreditLimit { get; set; }
        public DateTime CreditPeriod { get; set; }
        //public string? DocumentPath { get; set; }

    }
}
