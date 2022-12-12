using Corbet.Application.Features.Taxes.Commands.DeleteTaxType;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface ITaxRepository: IAsyncRepository<Tax>
    {

        public Task<DeleteTaxTypeDto> RemoveTaxTypeAsync(int TaxId, int? DeletedBy);
        public Task<List<Tax>> GetAllTaxes();
        public Task<bool> CheckTaxExists(string tax);

    }
}
