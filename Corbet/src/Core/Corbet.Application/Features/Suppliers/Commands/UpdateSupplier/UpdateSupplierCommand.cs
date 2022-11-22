using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand:IRequest<Response<UpdateSupplierCommandDto>>
    {

        public int Id { get; set; }
        public string SupplierName { get; set; }
        public long CreaditLimit { get; set; }

    }
}
