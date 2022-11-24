using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.ProductSubCategory.Command.DeleteSubCategory
{

    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, Response<DeleteSubCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSubCategoryCommandHandler> _logger;
        private readonly IProductSubCategoryRepo _productSubCategoryRepository;

        public DeleteSubCategoryCommandHandler(IMapper mapper, ILogger<DeleteSubCategoryCommandHandler> logger, IProductSubCategoryRepo productSubCategoryRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productSubCategoryRepository = productSubCategoryRepository;
        }

        public async Task<Response<DeleteSubCategoryDto>> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete SubCategory Initiated");
            var subCategoryDetailDto = await _productSubCategoryRepository.RemoveSubCategoryAsync(request.SubCategoryId);
            _logger.LogInformation("Delete  Completed");

            if (subCategoryDetailDto.Succeeded)
            {
                return new Response<DeleteSubCategoryDto>(subCategoryDetailDto, "Success");
            }
            else
            {
                var res = new Response<DeleteSubCategoryDto>(subCategoryDetailDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();


        }

    }
}