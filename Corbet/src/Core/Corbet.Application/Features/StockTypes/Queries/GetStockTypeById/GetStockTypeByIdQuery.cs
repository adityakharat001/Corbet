using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.StockTypes.Queries.GetStockTypeById
{
    public class GetStockTypeByIdQuery : IRequest<Response<GetStockTypeByIdVm>>
    {
        public int StockTypeId { get; set; }
    }
}
