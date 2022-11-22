using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.ProductCategory.Queries.CategoryNameExist
{
    public class CategoryNameExistQueryHandler:IRequestHandler<CategoryNameExistQuery, bool>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryNameExistQueryHandler> _logger;
        private readonly IProductCategoryRepo _categoryRepository;

        public CategoryNameExistQueryHandler(IMapper mapper, ILogger<CategoryNameExistQueryHandler> logger, IProductCategoryRepo productCategoryRepo)
        {
            _mapper=mapper;
            _logger=logger;
            _categoryRepository=productCategoryRepo;
        }

        public Task<bool> Handle(CategoryNameExistQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Categoruy exist checking started ");
            Task<bool> check = _categoryRepository.CheckCategoryExists(request.CategoryName);
            return check;
        }
    }
}
