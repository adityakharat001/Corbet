using Corbet.Application.Contracts.Persistence;
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
        public ProductRepository(ApplicationDbContext dbContext, ILogger<Product> logger) : base(dbContext, logger)
        {
        }

        public async Task<List<GetAllProductsVm>> GetAllProducts()
        {
            var productData = (from u in _dbContext.UnitMeasurements
                               join p in _dbContext.Products
                               on u.Id equals p.UnitId
                               join s in _dbContext.Suppliers
                               on p.PrimarySupplierId equals s.SupplierId
                               join sf in _dbContext.Suppliers
                               on p.SecondarySupplierId equals sf.SupplierId
                               join td in _dbContext.TaxDetails
                               on p.TaxId equals td.TaxId
                               join t in _dbContext.Taxes
                               on p.TaxId equals t.TaxId
                               where (p.Price > td.MinTax && p.Price < td.MaxTax) && p.IsDeleted == false
                               select new GetAllProductsVm
                               {
                                   Id = p.ProductId,
                                   ProductCode = p.ProductCode,
                                   ProductName = p.ProductName,
                                   Unit = u.Type,
                                   Price = p.Price,
                                   PrimarySupplier = s.SupplierName,
                                   SecondarySupplier = sf.SupplierName,
                                   ImagePath = p.ImagePath,
                                   Tax = t.Name,
                                   TaxApplicable = td.Percentage,
                                   IsActive = p.IsActive

                               }).ToList();
            
            return productData;
        }
    }
}
