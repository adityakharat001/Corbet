using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommand:IRequest<Response<DeleteProductCategoryCommandDto>>
    {
        public int CategoryId { get; set; }
    }
}
