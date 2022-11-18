using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails
{
    public class GetAlllCategoryDetailsQueryHandler:IRequestHandler<GetAllCategoryDetailsQuery, List<GetAllCategoryDetailsListVm>>
    {
        private readonly ILogger<GetAlllCategoryDetailsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoryDetailsRepo _categoryDetailsRepo;

        public GetAlllCategoryDetailsQueryHandler(ILogger<GetAlllCategoryDetailsQueryHandler> logger, IMapper mapper, ICategoryDetailsRepo categoryDetailsRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _categoryDetailsRepo = categoryDetailsRepo;
        }

        public async Task<List<GetAllCategoryDetailsListVm>> Handle(GetAllCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Category Details Initiated");
            var categoryData = await _categoryDetailsRepo.GetAllCategoryDetails();

            var categoryList = _mapper.Map<List<GetAllCategoryDetailsListVm>>(categoryData);

            _logger.LogInformation("Category details display successfully");
            return new List<GetAllCategoryDetailsListVm>(categoryList);
        }
    }
}
