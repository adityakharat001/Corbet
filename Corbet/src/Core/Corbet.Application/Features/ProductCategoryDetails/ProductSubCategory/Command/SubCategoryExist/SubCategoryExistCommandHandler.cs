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

namespace Corbet.Application.Features.ProductSubCategory.Command.SubCategoryExist
{
    public class SubCategoryExistCommandHandler : IRequestHandler<SubCategoryExistCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SubCategoryExistCommandHandler> _logger;
        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        public SubCategoryExistCommandHandler(IMapper mapper, ILogger<SubCategoryExistCommandHandler> logger, IProductSubCategoryRepo productSubCategoryRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _productSubCategoryRepo = productSubCategoryRepo;
        }
    
        public async Task<bool> Handle(SubCategoryExistCommand request, CancellationToken cancellationToken)
        {
            var subcategorydata = _mapper.Map<Domain.Entities.ProductSubCategory>(request);
            bool value=_productSubCategoryRepo.SubCategoryExist(subcategorydata);
            return value;
        }
    }
}
