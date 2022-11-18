using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails
{
    public class GetAllCategoryDetailsQuery:IRequest<List<GetAllCategoryDetailsListVm>>
    {
    }
}
