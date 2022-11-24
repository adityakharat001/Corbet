using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.SuppliersDetails.Command.DeleteSupplierDetails;
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

        public async Task<DeleteSupplierDetailsCommandDto> RemoveSupplierDetailsAsync(int id)
        {
            _logger.LogInformation("Initiated in repository");
            DeleteSupplierDetailsCommandDto response = new DeleteSupplierDetailsCommandDto();
            var IsSupplierExist = await _dbContext.SupplierDetails.Where(x => x.SupplierId == id).FirstOrDefaultAsync();
            if (IsSupplierExist != null)
            {
                IsSupplierExist.IsDeleted = true;
                await _dbContext.SaveChangesAsync();

                response.Message = "Category Details Successful";
                response.Succeeded = true;

                return response;
                _logger.LogInformation("remove category completed");
            }
            else
            {
                response.Message = "Category details with this id doesn't exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove Category deatils Doesn't exist");
            }

        }
        public Supplier SupplierDetailsAdding(SupplierDetails supplierDetails)
        {
            Supplier supplier = new Supplier()
            {
                uniqueId = supplierDetails.SupplierId,
                SupplierName = supplierDetails.SupplierName,
                CreaditLimit = supplierDetails.CreditLimit
            };
            return supplier;
        }






        public async Task<bool> ToggleActiveStatus(int supplierId)
        {
            _logger.LogInformation("In Repository Toggler Supplier Details Active Status Initiated");
            var supplierExist = await _dbContext.SupplierDetails.Where(x => x.SupplierId == supplierId).FirstOrDefaultAsync();
            if (supplierExist != null)
            {
                //if (supplierExist.)
                //{
                //    supplierExist.IsActive = false;
                //    _dbContext.SaveChanges();
                //    return false;
                //}
                //else if (!supplierExist.IsActive)
                //{
                //    supplierExist.IsActive = true;
                //    _dbContext.SaveChanges();
                //    return true;
                //}
                //return false;
            }
            return false;

        }
    }
}
