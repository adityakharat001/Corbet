using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQuery : IRequest<Response<Domain.Entities.ProductSubCategory>>
    {
        public int Id { get; set; }
        
        
    }
}
