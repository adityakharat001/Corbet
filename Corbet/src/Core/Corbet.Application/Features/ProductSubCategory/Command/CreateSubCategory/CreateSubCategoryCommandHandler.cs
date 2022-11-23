using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Roles.Commands.CreateRole;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductSubCategory.Command.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, Response<CreateSubCategoryDto>>
    {
        private readonly ILogger<CreateSubCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        public CreateSubCategoryCommandHandler(ILogger<CreateSubCategoryCommandHandler> logger, IMapper mapper, IProductSubCategoryRepo productSubCategoryRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _productSubCategoryRepo = productSubCategoryRepo;
        }

        public async Task<Response<CreateSubCategoryDto>> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var SubCategoryData = _mapper.Map<Domain.Entities.ProductSubCategory>(request);
           bool IsExist= _productSubCategoryRepo.SubCategoryExist(SubCategoryData);
            if (IsExist)
            {
                var SubCategoryAdded = await _productSubCategoryRepo.AddAsync(SubCategoryData);
                var productDto = _mapper.Map<CreateSubCategoryDto>(SubCategoryAdded);
                return new Response<CreateSubCategoryDto>(productDto);
            }

            else
            {
                return null;
            }


        }
    }
}