using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;

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
    public class SupplierDetailsRepository : BaseRepository<SupplierDetails>, ISupplierDetailsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SupplierDetailsRepository(ApplicationDbContext dbContext, ILogger<SupplierDetails> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryDetailsCommandDto> RemoveSupplierDetailsAsync(int supplierId)
        {
            _logger.LogInformation("In Repository Remove Supplier Initiated");
            DeleteCategoryDetailsCommandDto response = new DeleteCategoryDetailsCommandDto();
            var IsSupplierExist = await _dbContext.SupplierDetails.Where(x => x.SupplierId == supplierId).FirstOrDefaultAsync();
            if (IsSupplierExist != null)
            {

                IsSupplierExist.IsDeleted = true;
                IsSupplierExist.IsActive = false;
                await _dbContext.SaveChangesAsync();

                //response.Email = IsSupplierExist.Email;
                //response.SupplierName = IsSupplierExist.SupplierName;
                response.Message = "Supplier Details Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove Supplier Details Completed");
            }

            else
            {
                //response.Email = null;
                //response.SupplierName = null;
                response.Message = "Supplier Details with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Supplier Details Doesn't exist");
            }
        }

        public async Task<bool> ToggleActiveStatus(int supplierId)
        {
            _logger.LogInformation("In Repository Toggler Supplier Details Active Status Initiated");
            var supplierExist = await _dbContext.SupplierDetails.Where(x => x.SupplierId == supplierId).FirstOrDefaultAsync();
            if (supplierExist != null)
            {
                if (supplierExist.IsActive)
                {
                    supplierExist.IsActive = false;
                    _dbContext.SaveChanges();
                    return false;
                }
                else if (!supplierExist.IsActive)
                {
                    supplierExist.IsActive = true;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;

        }
    }
}
