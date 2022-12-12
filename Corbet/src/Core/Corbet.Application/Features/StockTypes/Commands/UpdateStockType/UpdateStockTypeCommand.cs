using Corbet.Application.Responses;
using MediatR;

namespace Corbet.Application.Features.StockTypes.Commands.UpdateStockType
{
    public class UpdateStockTypeCommand : IRequest<Response<UpdateStockTypeDto>>
    {
        public int StockTypeId { get; set; }
        public string StockTypeName { get; set; }
        public int? LastModifiedBy { get; set; }

    }
}
