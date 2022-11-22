using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryList
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,List<GetCategoryQueryVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryQueryHandler> _logger;
        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        public GetCategoryQueryHandler(IMapper mapper,ILogger<GetCategoryQueryHandler> logger,IProductSubCategoryRepo productSubCategoryRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _productSubCategoryRepo = productSubCategoryRepo;
        }
        
        public async Task<List<GetCategoryQueryVm>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sub Category Initiated");
            var subCategoryData = await _productSubCategoryRepo.GetAllSubCategoryDetail();

            var subCategoryList = _mapper.Map<List<GetCategoryQueryVm>>(subCategoryData);

            _logger.LogInformation("SubCategory display successfully");
            return new List<GetCategoryQueryVm>(subCategoryList);
        }
        //public Task<Unit> Handle(Response<GetSubCategoryQueryVm> request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
 