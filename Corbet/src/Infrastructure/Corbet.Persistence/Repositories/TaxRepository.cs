using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxType;
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
    public class TaxRepository : BaseRepository<Tax>, ITaxRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TaxRepository(ApplicationDbContext dbContext, ILogger<Tax> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<List<Tax>> GetAllTaxes()
        {
            List<Tax> taxes = await _dbContext.Taxes.Where(t => t.IsDeleted == false).ToListAsync();
            return taxes;
        }


        public Task<bool> CheckTaxExists(string tax)
        {
            string lowerCaseTax = tax.ToLower();
            Tax check = _dbContext.Taxes.Where(x => x.Name.ToLower() == lowerCaseTax).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public async Task<DeleteTaxTypeDto> RemoveTaxTypeAsync(int TaxId)
        {
            _logger.LogInformation("In Repository Remove tax type Initiated");
            DeleteTaxTypeDto response = new DeleteTaxTypeDto();
            var IsTaxTypeExist = await _dbContext.Taxes.Where(x => x.TaxId == TaxId).FirstOrDefaultAsync();
            if (IsTaxTypeExist != null)
            {

                IsTaxTypeExist.IsDeleted = true;

                await _dbContext.SaveChangesAsync();

                response.Name = IsTaxTypeExist.Name;
                response.Message = "Tax Type Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove tax type Completed");
            }

            else
            {
                response.Name = null;
                response.Message = "Tax Type with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove User Doesn't exist");
            }

        }


    }
}
