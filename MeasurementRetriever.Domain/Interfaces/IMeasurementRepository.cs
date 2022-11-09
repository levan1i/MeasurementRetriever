using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Domain.Interfaces
{
    public interface IMeasurmentRepository : IGenericRepository<AgregatedMeasurment>
    {
        Task<PagedResult<AgregatedMeasurment>> Get(int page, int pageSize);
        Task<bool> SaveAgregatedMeasurements(IEnumerable<AgregatedMeasurment> measurments);
    }
}
