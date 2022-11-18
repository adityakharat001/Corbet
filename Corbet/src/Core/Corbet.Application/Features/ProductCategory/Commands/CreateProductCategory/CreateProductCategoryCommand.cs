using Corbet.Application.Features.Categories.Commands.CreateCategory;
using Corbet.Application.Features.ProductCategory.Commands.CreateProductCategory;
using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory
{
    public class CreateProductCategoryCommand:IRequest<Response<CreateProductCategoryCommandDto>>
    {
        public string CategoryName { get; set; }
    }
}
