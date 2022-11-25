using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.StockTypes.Commands.DeleteStockType
{
    public class DeleteStockTypeCommand : IRequest<Response<DeleteStockTypeDto>>
    {
        public int StockTypeId { get; set; }
    }
}
