using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}
