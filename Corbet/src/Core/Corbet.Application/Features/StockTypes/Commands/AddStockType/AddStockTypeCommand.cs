using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.StockTypes.Commands.AddStockType
{
    public class AddStockTypeCommand : IRequest<Response<AddStockTypeDto>>
    {
        public string StockTypeName { get; set; }
        public int? CreatedBy { get; set; }

    }
}
