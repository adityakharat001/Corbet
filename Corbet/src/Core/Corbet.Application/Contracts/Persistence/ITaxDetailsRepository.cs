using Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ITaxDetailsRepository : IAsyncRepository<TaxDetail>
    {
        public Task<DeleteTaxDetailDto> RemoveTaxDetailsAsync(int TaxId, int? DeletedBy);
        public Task<List<GetTaxDetailListVm>> GetAllTaxDetails();
        public Task<bool> ToggleActiveStatus(int id);



    }
}
