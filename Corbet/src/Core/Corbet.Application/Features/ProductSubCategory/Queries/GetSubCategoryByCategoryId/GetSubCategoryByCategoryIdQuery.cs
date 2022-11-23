using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryByCategoryId
{
    public class GetSubCategoryByCategoryIdQuery: IRequest<List<GetSubCategoryByCategoryIdVm>>
    {
        public int CategoryId { get; set; }
    }
}
