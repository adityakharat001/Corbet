using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Suppliers.Commands.DeleteSupplier;
using Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Corbet.Persistence.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SupplierRepository(ApplicationDbContext dbContext, ILogger<Supplier> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CheckSupplierExists(string supplier)
        {
            var supplierExist = await _dbContext.Suppliers.FirstOrDefaultAsync(s => s.SupplierName.Equals(supplier) && s.IsDeleted==false);
            if (supplierExist is not null)
            {
                return false;
            }
            else return true;
        }

        public List<Supplier> GetAllSuppliers()
        {
            var suppliers = _dbContext.Suppliers.Where(s => s.IsDeleted != true).ToList();
            return suppliers;
        }

        public List<Supplier> GetAllSuppliersForPurchaseUser()
        {
            var suppliers = _dbContext.Suppliers.Where(s => s.IsDeleted != true && s.IsActive != false).ToList();
            return suppliers;
        }

        public async Task<DeleteSupplierCommandDto> RemoveSupplierAsync(int supplierId, int? deletedBy)
        {
            _logger.LogInformation("In Repository Remove Supplier Initiated");
            DeleteSupplierCommandDto response = new DeleteSupplierCommandDto();
            var IsSupplierExist = await _dbContext.Suppliers.Where(x => x.SupplierId == supplierId).FirstOrDefaultAsync();
            if (IsSupplierExist != null)
            {
                IsSupplierExist.DeletedBy = deletedBy;
                IsSupplierExist.DeletedDate = DateTime.Now;
                IsSupplierExist.IsDeleted = true;
                IsSupplierExist.IsActive = false;
                await _dbContext.SaveChangesAsync();

                response.Email = IsSupplierExist.Email;
                response.SupplierName = IsSupplierExist.SupplierName;
                response.Message = "Supplier Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove Supplier Completed");
            }

            else
            {
                response.Email = null;
                response.SupplierName = null;
                response.Message = "Supplier with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Supplier Doesn't exist");
            }
        }



        public async Task<bool> ToggleActiveStatus(int supplierId)
        {
            _logger.LogInformation("In Repository Toggler Supplier Active Status Initiated");
            var supplierExist = await _dbContext.Suppliers.Where(x => x.SupplierId == supplierId).FirstOrDefaultAsync();
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
