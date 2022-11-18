using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Command.SubCategoryExist
{
    public class SubCategoryExistCommand:IRequest<bool>
    {
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
