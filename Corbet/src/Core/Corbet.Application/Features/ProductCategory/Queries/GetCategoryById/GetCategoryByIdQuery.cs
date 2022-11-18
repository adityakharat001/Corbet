using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery:IRequest<Response<Domain.Entities.ProductCategory>>
    {
        public int CategoryId { get; set; }
    }
}
