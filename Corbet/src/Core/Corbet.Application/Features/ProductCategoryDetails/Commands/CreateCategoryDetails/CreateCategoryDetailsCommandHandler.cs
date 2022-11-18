using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.CreateCategoryDetails
{
    public class CreateCategoryDetailsCommandHandler:IRequestHandler<CreateCategoryDetailsCommand, Response<CreateCategoryDetailsCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCategoryDetailsCommandHandler> _logger;
        private readonly ICategoryDetailsRepo _categoryDetailsRepo;
        public CreateCategoryDetailsCommandHandler(IMapper mapper, ILogger<CreateCategoryDetailsCommandHandler> logger, ICategoryDetailsRepo categoryDetailsRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryDetailsRepo = categoryDetailsRepo;
        }

        public async Task<Response<CreateCategoryDetailsCommandDto>> Handle(CreateCategoryDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("creating category details initiated");

             var details=_mapper.Map<Domain.Entities.ProductCategoryDetail>(request);

             var detailsDto=  await _categoryDetailsRepo.AddAsync(details);

            var detailsData = _mapper.Map<CreateCategoryDetailsCommandDto>(detailsDto);

            _logger.LogInformation("created successfully");

            return new Response<CreateCategoryDetailsCommandDto>(detailsData);

        }
    }
}
