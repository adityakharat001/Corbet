using Corbet.Domain.Entities;
using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
        Task<Category> AddCategory(Category category);
    }
}
