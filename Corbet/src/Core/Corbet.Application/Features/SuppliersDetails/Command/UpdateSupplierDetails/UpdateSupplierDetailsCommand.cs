using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.SuppliersDetails.Command.UpdateSupplierDetails
{
    public class UpdateSupplierDetailsCommand : IRequest<Response<UpdateSupplierDetailsCommandDto>>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public long CreditLimit { get; set; }
      
    }

}
