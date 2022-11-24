using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;

using MediatR;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryByCategoryId
{
    public class GetSubCategoryByCategoryIdQueryHandler:IRequestHandler<GetSubCategoryByCategoryIdQuery, List<GetSubCategoryByCategoryIdVm>>
    {
        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        private readonly IMapper _mapper;

        public GetSubCategoryByCategoryIdQueryHandler(IProductSubCategoryRepo productSubCategoryRepo, IMapper mapper)
        {
            _productSubCategoryRepo = productSubCategoryRepo;
            _mapper = mapper;
        }

        public async Task<List<GetSubCategoryByCategoryIdVm>> Handle(GetSubCategoryByCategoryIdQuery request, CancellationToken cancellationToken)
        {

            List<GetSubCategoryByCategoryIdVm> subCategory = _productSubCategoryRepo.GetSubCategoryByCategoryId(request.CategoryId);
            var subCategoryList = _mapper.Map<List<GetSubCategoryByCategoryIdVm>>(subCategory);
            return new List<GetSubCategoryByCategoryIdVm>(subCategoryList);
        }

    }
}
