﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Domain.Entities;

using MediatR;

namespace Corbet.Application.Features.SuppliersDetails.Queries.GetSupplierDetailsById
{
    public class GetSupplierDetailsByIdQuery:IRequest<SupplierDetails>
    {
        public int SupplierId { get; set; }
    }
}
