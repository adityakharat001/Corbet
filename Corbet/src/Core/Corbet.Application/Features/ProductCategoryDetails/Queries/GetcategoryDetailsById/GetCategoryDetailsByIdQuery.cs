﻿using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Queries.GetcategoryDetailsById
{
    public class GetCategoryDetailsByIdQuery : IRequest<Response<Domain.Entities.ProductCategoryDetail>>
    {
        public int Id { get; set; }
    }
}
