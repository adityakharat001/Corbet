using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.SuppliersDetails.Command.CreateSupplierDetails;
using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommand:IRequest<Response<CreateSuplierCommandDto>>
    {

        public string SupplierName { get; set; }
        public long CreaditLimit { get; set; }
      
    }
}
