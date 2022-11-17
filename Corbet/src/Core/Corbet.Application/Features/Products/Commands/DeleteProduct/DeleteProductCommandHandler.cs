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

namespace Corbet.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<DeleteProductCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IMapper mapper, ILogger<DeleteProductCommandHandler> logger, IProductRepository productRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<Response<DeleteProductCommandDto>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Delete product Initiated");
            var productDto = await _productRepository.RemoveProductAsync(request.Id);
            _logger.LogInformation("Delete product Completed");
            if (productDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(productdto);
                return new Response<DeleteProductCommandDto>(productDto, "Success");
            }
            else
            {
                var res = new Response<DeleteProductCommandDto>(productDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
        }
    }
}