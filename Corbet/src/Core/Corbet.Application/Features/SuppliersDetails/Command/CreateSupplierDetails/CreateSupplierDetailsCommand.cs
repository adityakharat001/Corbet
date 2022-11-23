using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.SuppliersDetails.Command.CreateSupplierDetails
{
    public class CreateSupplierDetailsCommand : IRequest<Response<CreateSupplierDetailsCommandDto>>
    {
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string SupplierType { get; set; }
        public long CreditLimit { get; set; }
   
    

    }

}
