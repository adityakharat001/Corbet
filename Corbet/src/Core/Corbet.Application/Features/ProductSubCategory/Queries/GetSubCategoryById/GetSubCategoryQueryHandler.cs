using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Queries.GetTaxById;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryById
{
   
    public class GetSubCategoryQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, Response<Domain.Entities.ProductSubCategory>>
    {

        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        private readonly IMapper _mapper;

        public GetSubCategoryQueryHandler(IProductSubCategoryRepo productSubCategoryRepo, IMapper mapper)
        {
            _productSubCategoryRepo = productSubCategoryRepo;
            _mapper = mapper;
        }

        public async Task<Response<Domain.Entities.ProductSubCategory>> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var subCategory = await _productSubCategoryRepo.GetById(request.Id);
            if (subCategory.IsDeleted)
            {
                return null;
            }
            return new Response<Domain.Entities.ProductSubCategory>(subCategory);
        }
    }
}
