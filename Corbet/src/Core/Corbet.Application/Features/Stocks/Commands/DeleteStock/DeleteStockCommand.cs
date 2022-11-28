using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommand : IRequest<Response<DeleteStockDto>>
    {
        public int StockId { get; set; }
    }
}
