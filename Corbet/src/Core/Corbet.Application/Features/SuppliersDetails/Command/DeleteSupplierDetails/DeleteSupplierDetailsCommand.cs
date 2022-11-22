using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.SuppliersDetails.Command.DeleteSupplierDetails
{
    public class DeleteSupplierDetailsCommand : IRequest<Response<DeleteSupplierDetailsCommandDto>>
    {
        public int SupplierId { get; set; }
       

        public DeleteSupplierDetailsCommand(int id)
        {
            SupplierId = id;
        }
    }
}
