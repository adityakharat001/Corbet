using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Exceptions;
using Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails
{
    public class UpdateCategoryDetailsCommandHandler:IRequestHandler<UpdateCategoryDetailsCommand, Response<UpdateCategoryDetailsCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryDetailsCommandHandler> _logger;
        private readonly ICategoryDetailsRepo _categoryDetailsRepo;

        public UpdateCategoryDetailsCommandHandler(IMapper mapper,ILogger<UpdateCategoryDetailsCommandHandler> logger,ICategoryDetailsRepo categoryDetailsRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryDetailsRepo = categoryDetailsRepo;
        }

        public async Task<Response<UpdateCategoryDetailsCommandDto>> Handle(UpdateCategoryDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update categoryDetails initiated");
            var category = await _categoryDetailsRepo.GetById(request.Id);
            if (category == null)
            {
                throw new NotFoundException(nameof(ProductCategoryDetail), request.Id);
            }
            var categoryData = _mapper.Map(request, category);
            await _categoryDetailsRepo.UpdateAsync(categoryData);
            var categoryDto=_mapper.Map<UpdateCategoryDetailsCommandDto>(categoryData);
            _logger.LogInformation("updated");
            return new Response<UpdateCategoryDetailsCommandDto> (categoryDto);

        }
    }
}
