using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.CreateCategoryDetails
{
    public class CreateCategoryDetailsCommand:IRequest<Response<CreateCategoryDetailsCommandDto>>

    {
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
    }
}
