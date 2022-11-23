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

namespace Corbet.Application.Features.ProductSubCategory.Command.UpdateSubCategory
{

    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, Response<UpdateSubCategoryDto>>
    {
        private readonly ILogger<UpdateSubCategoryCommandHandler> _logger;
        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        private readonly IMapper _mapper;

        public UpdateSubCategoryCommandHandler(ILogger<UpdateSubCategoryCommandHandler> logger, IProductSubCategoryRepo productSubCategoryRepo, IMapper mapper)
        {
            _logger = logger;
            _productSubCategoryRepo = productSubCategoryRepo;
            _mapper = mapper;
        }
        public async Task<Response<UpdateSubCategoryDto>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update subCategory initiated");
            var subcategory = await _productSubCategoryRepo.GetById(request.Id);
            if (subcategory == null)
            {
                throw new NotFoundException(nameof(ProductSubCategory), request.Id);
            }

            var subCategoryData = _mapper.Map(request, subcategory);
            await _productSubCategoryRepo.UpdateAsync(subCategoryData);
            var subCategoryDto = _mapper.Map<UpdateSubCategoryDto>(subCategoryData);
            _logger.LogInformation("Update SubCategory completed");
            return new Response<UpdateSubCategoryDto>(subCategoryDto);
        }
    }
}
