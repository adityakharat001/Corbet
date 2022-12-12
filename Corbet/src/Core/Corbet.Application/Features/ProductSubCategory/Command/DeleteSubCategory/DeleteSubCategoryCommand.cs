using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.ProductSubCategory.Command.DeleteSubCategory
{

    public class DeleteSubCategoryCommand : IRequest<Response<DeleteSubCategoryDto>>
    {
        public int SubCategoryId { get; set; }
        public int? DeletedBy { get; set; }

    }
}
