using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails
{
    public class DeleteCategoryDetailsCommand:IRequest<Response<DeleteCategoryDetailsCommandDto>>
    {
        public int Id { get; set; }
    }
}
