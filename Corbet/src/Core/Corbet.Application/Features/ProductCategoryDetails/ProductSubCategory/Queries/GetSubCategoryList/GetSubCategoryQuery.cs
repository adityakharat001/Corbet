﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryList
{
    public class GetCategoryQuery:IRequest<List<GetCategoryQueryVm>>
    {
    }
}
