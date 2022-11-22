using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail;
using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.ProductSubCategory.Command.UpdateSubCategory
{
    public class UpdateSubCategoryCommand: IRequest<Response<UpdateSubCategoryDto>>
    {
        public int Id { get; set; }
        public  int CategoryId { get; set; }
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public string? Description { get; set; }
        public  int TaxId { get; set; }
        public bool Status { get; set; }



    }
}
