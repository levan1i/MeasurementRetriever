using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Domain.Interfaces
{
    public interface IDatasetRepository : IGenericRepository<DatasetInfo>
    {
        Task<List<DatasetInfo>> GetUnprocessed();
        Task<PagedResult<DatasetInfo>> Get(int page, int pageSize);
    }

}
