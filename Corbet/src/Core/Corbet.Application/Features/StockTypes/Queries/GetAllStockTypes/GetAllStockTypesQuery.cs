using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.StockTypes.Queries.GetAllStockTypes
{
    public class GetAllStockTypesQuery : IRequest<Response<List<GetAllStockTypesVm>>> { }
}
