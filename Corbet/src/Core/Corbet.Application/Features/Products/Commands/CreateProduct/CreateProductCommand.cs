using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Response<CreateProductCommandDto>>
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }
        public int PrimarySupplierId { get; set; }
        public int SecondarySupplierId { get; set; }
        public string? ImagePath { get; set; }
        public int TaxId { get; set; }
        public int? CreatedBy { get; set; }


    }
}
