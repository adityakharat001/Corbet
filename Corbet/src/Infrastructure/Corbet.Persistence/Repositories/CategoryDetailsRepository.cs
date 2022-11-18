using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails;
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
    public class CategoryDetailsRepository : BaseRepository<ProductCategoryDetail>, ICategoryDetailsRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CategoryDetailsRepository(ApplicationDbContext dbContext, ILogger<ProductCategoryDetail> logger,IMapper mapper) : base(dbContext, logger)
        {
            _logger= logger;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryDetailsCommandDto> RemoveCategoryDetailsAsync(int id)
        {
            _logger.LogInformation("Initiated in repository");
            DeleteCategoryDetailsCommandDto response = new DeleteCategoryDetailsCommandDto();
            var IsCategoryExist = await _dbContext.ProductCategoryDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (IsCategoryExist!=null)
            {
                IsCategoryExist.IsDeleted = true;
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
        public async Task<List<GetAllCategoryDetailsListVm>> GetAllCategoryDetails()
        {
            //var taxdta=_dbContext.TaxesDetails.
            var categorydata = (from p in _dbContext.ProductCategories
                          join e in _dbContext.ProductCategoryDetails
                          on p.CategoryId equals e.CategoryId
                          where e.IsDeleted == false
                          select new GetAllCategoryDetailsListVm
                          {
                              Id = e.Id,
                              CategoryName = p.CategoryName,
                              CategoryDiscription = e.CategoryDiscription,
                              Status = e.Status,                         

                          }).ToList();

            //var taxdta = _dbContext.TaxesDetails.Include(n => n.TaxId).Where(x => x.IsDeleted == false).ToList();
            //var  n= _mapper.Map<GetTaxListVm>(taxdta);
            return categorydata;
        }


    }
}
