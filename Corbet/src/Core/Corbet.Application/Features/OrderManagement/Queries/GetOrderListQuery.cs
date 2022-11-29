using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;

using MediatR;

namespace Corbet.Application.Features.OrderManagement.Queries
{
    public class GetOrderListQuery : IRequest<List<GetOrderListVm>>
    {


    }
}
