using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Command.CreateSubCategory
{
    public class CreateSubCategoryCommand : IRequest<Response<CreateSubCategoryDto>>
    {
        public int CategoryId { get; set; }

        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public int TaxId { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }


    }
}
