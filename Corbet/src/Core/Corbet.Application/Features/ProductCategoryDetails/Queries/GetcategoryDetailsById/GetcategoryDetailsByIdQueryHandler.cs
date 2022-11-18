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

namespace Corbet.Application.Features.ProductCategoryDetails.Queries.GetcategoryDetailsById
{
    public class GetcategoryDetailsByIdQueryHandler:IRequestHandler<GetCategoryDetailsByIdQuery, Response<Domain.Entities.ProductCategoryDetail>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetcategoryDetailsByIdQueryHandler> _logger;
        private readonly ICategoryDetailsRepo _categoryDetailsRepo;
        public GetcategoryDetailsByIdQueryHandler(IMapper mapper, ILogger<GetcategoryDetailsByIdQueryHandler> logger, ICategoryDetailsRepo categoryDetailsRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryDetailsRepo = categoryDetailsRepo;
        }

        public async Task<Response<ProductCategoryDetail>> Handle(GetCategoryDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initiated");
            var details = await _categoryDetailsRepo.GetById(request.Id);
            if (details.IsDeleted)
            {
                return null;
            }
            return new Response<ProductCategoryDetail>(details);


        }
    }
}
