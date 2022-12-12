using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Suppliers.Commands.CheckSupplierExists
{
    public class CheckSupplierExistsCommand : IRequest<Response<bool>>
    {
        public string SupplierName { get; set; }
    }
}
