using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommandHandler:IRequestHandler<DeleteProductCategoryCommand, Response<DeleteProductCategoryCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCategoryCommandHandler> _logger;
        private readonly IProductCategoryRepo _productCategoryRepo;

        public DeleteProductCategoryCommandHandler(IMapper mapper, ILogger<DeleteProductCategoryCommandHandler> logger, IProductCategoryRepo productCategoryRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _productCategoryRepo = productCategoryRepo;
        }
 
        public async Task<Response<DeleteProductCategoryCommandDto>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete category initiated");
            var categoryDto = await _productCategoryRepo.RemoveCategoryAsync(request.CategoryId, request.DeletedBy);
            _logger.LogInformation("Delete Category Completed");
            if (categoryDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteProductCategoryCommandDto>(categoryDto, "Success");
            }
            else
            {
                var res = new Response<DeleteProductCategoryCommandDto>(categoryDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();



        }
    }
}
