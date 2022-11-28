using AutoMapper;

using Corbet.Application.Contracts.Persistence;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Queries
{
    public class GetCartListQueryHandler : IRequestHandler<GetCartListQuery, List<GetCartListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetCartListQueryHandler> _logger;
        private readonly ICartRepo _cartRepo;
        public GetCartListQueryHandler(IMapper mapper, ILogger<GetCartListQueryHandler> logger, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _cartRepo = cartRepo;
        }
        public async Task<List<GetCartListVm>> Handle(GetCartListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Cart List inintiated");

            var allcart = await _cartRepo.GetAllCart(request.userId);

            //var cartData = _mapper.Map<List<GetCartListVm>>(allcart);

            _logger.LogInformation("Displayed all cart successfully");

            return new List<GetCartListVm>(allcart);
        }
    }
}

