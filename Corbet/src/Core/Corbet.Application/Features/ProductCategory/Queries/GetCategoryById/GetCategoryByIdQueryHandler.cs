using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery, Response<Domain.Entities.ProductCategory>>
    {
        private readonly ILogger<GetCategoryByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepo _productCategoryRepo;

        public GetCategoryByIdQueryHandler(ILogger<GetCategoryByIdQueryHandler> logger, IMapper mapper, IProductCategoryRepo productCategoryRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<Response<Domain.Entities.ProductCategory>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _productCategoryRepo.GetById(request.CategoryId);
            if (category.IsDeleted)
            {
                return null;
            }
            return new Response<Domain.Entities.ProductCategory>(category);
        }
    }
}
