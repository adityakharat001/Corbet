using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Features.AddCart.Queries;
using Corbet.Domain.Entities;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IOrderManagementRepo : IAsyncRepository<OrderManagement>
    {
        Task<List<GetCartListVm>> GetAllCart(int userId);  
    }
}
