using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
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
    public class TaxDetailsRepository : BaseRepository<TaxDetail>, ITaxDetailsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TaxDetailsRepository(ApplicationDbContext dbContext, ILogger<TaxDetail> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<DeleteTaxDetailDto> RemoveTaxDetailsAsync(int Id)
        {
            _logger.LogInformation("In Repository Remove tax type Initiated");
            DeleteTaxDetailDto response = new DeleteTaxDetailDto();
            var IsTaxTypeExist = await _dbContext.TaxDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (IsTaxTypeExist != null)
            {

                IsTaxTypeExist.IsDeleted = true;

                await _dbContext.SaveChangesAsync();

                response.Message = "Tax Details Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove tax type Completed");
            }

            else
            {
                response.Message = "Tax Details with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove User Doesn't exist");
            }

        }

        //public async Task<List<TaxDetail>> GetAllTaxDetails()
        //{
        //    List<TaxDetail> taxDetail = await _dbContext.TaxDetails.Where(t => t.IsDeleted == false).ToListAsync();
        //    return taxDetail;
        //}

        public async Task<List<GetTaxDetailListVm>> GetAllTaxDetails()
        {
            //var taxdta=_dbContext.TaxesDetails.
            var taxdta = (from p in _dbContext.Taxes
                          join e in _dbContext.TaxDetails
                          on p.TaxId equals e.TaxId
                          where e.IsDeleted == false
                          select new GetTaxDetailListVm
                          {
                              Id = e.Id,
                              Name = p.Name,
                              MinTax = e.MinTax,
                              MaxTax = e.MaxTax,
                              Status = e.Status,
                              Percentage = e.Percentage

                          }).ToList();

            //var taxdta = _dbContext.TaxesDetails.Include(n => n.TaxId).Where(x => x.IsDeleted == false).ToList();
            //var  n= _mapper.Map<GetTaxListVm>(taxdta);
            return taxdta;
        }

    }
}
