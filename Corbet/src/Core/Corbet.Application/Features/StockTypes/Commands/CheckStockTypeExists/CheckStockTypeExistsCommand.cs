using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.StockTypes.Commands.CheckStockTypeExists
{
    public class CheckStockTypeExistsCommand : IRequest<Response<bool>>
    {
        public string StockTypeName { get; set; }
    }
}
