using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand: IRequest<Response<UpdateSupplierCommandDto>>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        //public string? DocumentPath { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
