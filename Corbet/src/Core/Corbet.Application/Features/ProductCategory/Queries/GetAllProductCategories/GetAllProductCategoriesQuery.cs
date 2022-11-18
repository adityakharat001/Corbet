using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQuery:IRequest<List<GetAllProductCategoriesVm>>
    {
    }
}
