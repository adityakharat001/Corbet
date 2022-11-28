using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.Stocks.Queries.GetStockByStockId
{
    public class GetStockByStockIdQuery : IRequest<Response<GetStockByStockIdVm>>
    {
        public int StockId { get; set; }
    }
}
