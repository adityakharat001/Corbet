using Corbet.Application.Contracts.Persistence;
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
    public class UnitMeasurementRepository : BaseRepository<UnitMeasurement>, IUnitMeasurementRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitMeasurementRepository(ApplicationDbContext dbContext, ILogger<UnitMeasurement> logger) : base(dbContext, logger)
        {
        }

        public async Task<bool> CheckIfUnitTypeAlreadyExists(string unitType)
        {
            var unitTypeExists = await _dbContext.UnitMeasurements.Where(e => e.Type == unitType).FirstOrDefaultAsync();
            if (unitTypeExists is not null)
            {
                return false;
            }
            else return true;
        }

        public async Task<UnitMeasurement> GetByTypeAsync(string type)
        {
            return await _dbContext.UnitMeasurements.FirstOrDefaultAsync(u => u.Type.Equals(type));
        }
        //public virtual async Task<UnitMeasurement> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<UnitMeasurement>().FindAsync(id);
        //}

    }
}
