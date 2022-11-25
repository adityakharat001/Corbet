using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery:IRequest<Supplier>
    {
        public int SupplierId { get; set; }
    }
}
