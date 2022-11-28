using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierAdminCommand:IRequest<Response<UpdateSupplierAdminCommandDto>>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public int CreditLimit { get; set; }
        public bool IsPaymentDone { get; set; }
    }
}
