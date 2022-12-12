using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Response<DeleteProductCommandDto>>
    {
        public int Id { get; set; }
        public int? DeletedBy { get; set; }
    }
}
