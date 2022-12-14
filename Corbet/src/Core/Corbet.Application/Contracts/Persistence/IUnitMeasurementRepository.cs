using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IUnitMeasurementRepository : IAsyncRepository<UnitMeasurement>
    {
        Task<UnitMeasurement> GetByTypeAsync(string type);
        Task<bool> CheckIfUnitTypeAlreadyExists(string unit);
        Task<IReadOnlyList<UnitMeasurement>> ListAllAsyncAddOn();
    }
}
