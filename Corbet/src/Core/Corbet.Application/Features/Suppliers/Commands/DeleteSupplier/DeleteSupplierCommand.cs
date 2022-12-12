using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<Response<DeleteSupplierCommandDto>>
    {
        public int SupplierId { get; set; }
        public int? DeletedBy { get; set; }
    }
}
