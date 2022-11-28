using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Products.Commands.DeleteProduct;
using Corbet.Application.Features.Products.Queries.GetAllProducts;
using Corbet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;
        public ProductRepository(ApplicationDbContext dbContext, ILogger<Product> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<GetAllProductsVm>> GetAllProducts()
        {
            var productData = (from u in _dbContext.UnitMeasurements
                               join p in _dbContext.Products
                               on u.Id equals p.UnitId
                               join s in _dbContext.SupplierDetails
                               on p.PrimarySupplierId equals s.SupplierId
                               join sf in _dbContext.SupplierDetails
                               on p.SecondarySupplierId equals sf.SupplierId
                               join td in _dbContext.TaxDetails
                               on p.TaxId equals td.TaxId
                               join t in _dbContext.Taxes
                               on p.TaxId equals t.TaxId
                               join c in _dbContext.ProductCategories
                               on p.CategoryId equals c.CategoryId
                               join sc in _dbContext.ProductSubCategories
                               on p.SubCategoryId equals sc.SubCategoryId
                               where (p.Price > td.MinTax && p.Price < td.MaxTax) && p.IsDeleted == false
                               select new GetAllProductsVm
                               {
                                   Id = p.ProductId,
                                   ProductCode = p.ProductCode,
                                   ProductName = p.ProductName,
                                   ProductCategory = c.CategoryName,
                                   ProductSubCategory = sc.SubCategoryName,
                                   Unit = u.Type,
                                   Price = p.Price,
                                   PrimarySupplier = s.SupplierName,
                                   SecondarySupplier = sf.SupplierName,
                                   ImagePath = p.ImagePath,
                                   Tax = t.Name,
                                   TaxApplicable = td.Percentage,
                                   IsActive = p.IsActive

                               }).ToList();
            _logger.LogInformation("Ge");
            
            return productData;
        }

        public async Task<DeleteProductCommandDto> RemoveProductAsync(int id)
        {
            _logger.LogInformation("In Repository Remove Product Initiated");
            DeleteProductCommandDto response = new DeleteProductCommandDto();
            var IsProductExist = await _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            if (IsProductExist != null)
            {

                IsProductExist.IsDeleted = true;
                IsProductExist.IsActive = false;
                await _dbContext.SaveChangesAsync();

                response.ProductCode = IsProductExist.ProductCode;
                response.ProductName = IsProductExist.ProductName;
                response.Message = "Product Deleted Successfully";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove Product Completed");
            }

            else
            {
                response.ProductCode = null;
                response.ProductName = null;
                response.Message = "Product with this Id don't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove Product Failed");
            }
        }
    }
}
