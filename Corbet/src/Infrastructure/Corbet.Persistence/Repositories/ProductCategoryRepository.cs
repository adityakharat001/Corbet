using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProductCategoryRepository(ApplicationDbContext dbContext, ILogger<ProductCategory> logger,IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        //get all categories
        public async Task<List<ProductCategory>> GetAllCategories()
        {
            List<ProductCategory> product = await _dbContext.ProductCategories.Where(a => a.IsDeleted==false).ToListAsync();
            return product;
        }


        //soft delete
        public async Task<DeleteProductCategoryCommandDto> RemoveCategoryAsync(int categoryId)
        {
            _logger.LogInformation("In Repository Remove Product Category Initiated");
            DeleteProductCategoryCommandDto response = new DeleteProductCategoryCommandDto();
            var IsProductCateoryExist = await _dbContext.ProductCategories.Where(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            if (IsProductCateoryExist != null)
            {

                IsProductCateoryExist.IsDeleted = true;
                await _dbContext.SaveChangesAsync();

                response.CategoryName = IsProductCateoryExist.CategoryName;
                response.Message = "Product Category  Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove Product Category Completed");
            }

            else
            {
                response.CategoryName = null;
                response.Message = "Product Category with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove Product Category Doesn't exist");
            }

        }

        //check category exist

        public Task<bool> CheckCategoryExists(string category)
        {
            string lowerCaseTax = category.ToLower();
            ProductCategory check = _dbContext.ProductCategories.Where(x => x.CategoryName.ToLower() == lowerCaseTax).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
