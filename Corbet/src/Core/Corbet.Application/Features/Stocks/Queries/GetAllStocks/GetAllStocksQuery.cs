using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Stocks.Queries.GetAllStocks
{
    public class GetAllStocksQuery : IRequest<Response<List<GetAllStocksVmOut>>>
    {
    }
}
