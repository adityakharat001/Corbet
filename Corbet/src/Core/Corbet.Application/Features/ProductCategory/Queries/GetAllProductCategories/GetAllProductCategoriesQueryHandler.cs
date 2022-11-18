using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxes;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories
{
    public class GetAllProductCategoriesQueryHandler:IRequestHandler<GetAllProductCategoriesQuery, List<GetAllProductCategoriesVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductCategoriesQueryHandler> _logger;
        private readonly IProductCategoryRepo _productCategoryRepo;
        public GetAllProductCategoriesQueryHandler(IMapper mapper, ILogger<GetAllProductCategoriesQueryHandler> logger, IProductCategoryRepo productCategoryRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<List<GetAllProductCategoriesVm>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Categories inintiated");

            var alltax = await _productCategoryRepo.GetAllCategories();

            var taxData = _mapper.Map<List<GetAllProductCategoriesVm>>(alltax);

            _logger.LogInformation("Displayed all taxes successfully");

            return new List<GetAllProductCategoriesVm>(taxData);
        }
    }
}
