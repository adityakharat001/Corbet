using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductSubCategory.Command.DeleteSubCategory;
using Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryList;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Persistence.Repositories
{
    public class ProductSubCategoryRepo : BaseRepository<ProductSubCategory>, IProductSubCategoryRepo
    {
        public ProductSubCategoryRepo(ApplicationDbContext dbContext, ILogger<ProductSubCategory> logger) : base(dbContext, logger)
        {

        }

        public async Task<List<GetCategoryQueryVm>> GetAllSubCategoryDetail()
        {
            //var taxdta=_dbContext.TaxesDetails.
            var subcategorydata = (from p in _dbContext.ProductCategories
                                   join e in _dbContext.ProductSubCategories
                                   on p.CategoryId equals e.CategoryId
                                   join z in _dbContext.Taxes
                                   on e.TaxId equals z.TaxId
                                   where e.IsDeleted == false
                                   select new GetCategoryQueryVm
                                   {
                                       SubCategoryId = e.SubCategoryId,
                                       CategoryName = p.CategoryName,
                                       SubCategoryName = e.SubCategoryName,
                                       Description = e.Description,
                                       Status = e.Status,

                                       TaxName = z.Name

                                   }).ToList();
            return subcategorydata;
        }



        //subCategory Exist
        public bool SubCategoryExist(ProductSubCategory productSubCategory)
        {
            var value = _dbContext.ProductSubCategories.Where(x => x.CategoryId == productSubCategory.CategoryId && x.SubCategoryName == productSubCategory.SubCategoryName && x.TaxId == productSubCategory.TaxId).FirstOrDefault();
            
            if (value == null)
            {
                return true;
            }
            else
            {
                if (value.IsDeleted)
                {
                    return true;
                }
                    return false;
            }
           
        }


        public async Task<DeleteSubCategoryDto> RemoveSubCategoryAsync(int Id)
        {
            DeleteSubCategoryDto response = new DeleteSubCategoryDto();
            var IsSubCategoryExist = await _dbContext.ProductSubCategories.Where(x => x.SubCategoryId == Id).FirstOrDefaultAsync();
            if (IsSubCategoryExist != null)
            {

                IsSubCategoryExist.IsDeleted = true;
                IsSubCategoryExist.Status = false;

                await _dbContext.SaveChangesAsync();
                response.SubCategoryName = IsSubCategoryExist.SubCategoryName;
                response.Message = "SubCategory Deleted Successful";
                response.Succeeded = true;
                return response;
            }

            else
            {
                response.Message = "SubCategory with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
            }

        }
    }
}
