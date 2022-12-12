using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand:IRequest<Response<UpdateProductCategoryCommandDto>>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? LastModifiedBy { get; set; }

    }
}
