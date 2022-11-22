using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails
{
    public class UpdateCategoryDetailsCommand:IRequest<Response<UpdateCategoryDetailsCommandDto>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
    }
}
