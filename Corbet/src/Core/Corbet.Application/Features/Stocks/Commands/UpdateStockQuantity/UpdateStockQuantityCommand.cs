using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Stocks.Commands.UpdateStockQuantity
{
    public class UpdateStockQuantityCommand:IRequest<Response<UpdateStockQuantityDto>>
    {
        public int UserId { get; set; }
    }
}
