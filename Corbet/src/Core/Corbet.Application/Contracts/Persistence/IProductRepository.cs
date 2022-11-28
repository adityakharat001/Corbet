using Corbet.Application.Features.Products.Commands.DeleteProduct;
using Corbet.Application.Features.Products.Queries.GetAllProducts;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        public Task<List<GetAllProductsVm>> GetAllProducts();
        Task<DeleteProductCommandDto> RemoveProductAsync(int id);
        Task<Product> GetByIdAsync(int productId);
    }
}
