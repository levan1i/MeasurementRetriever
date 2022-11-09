using MeasurementRetriever.Common.Extentions;
using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Interfaces;
using MeasurementRetriever.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Repository
{
    internal class DatasetRepository : Genericrepository<DatasetInfo>, IDatasetRepository
    {
        public DatasetRepository(MeasurementRetrieverDbContext context) : base(context)
        {
        }

        public Task<PagedResult<DatasetInfo>> Get(int page, int pageSize)
        {
            return _context.DatasetInfo.OrderByDescending(x => x.Id).GetPagedResultAsync(page, pageSize);
        }

        public  Task<List<DatasetInfo>> GetUnprocessed()
        {
            return  _context.DatasetInfo.Where(x => x.StatusCode=="Created").ToListAsync();
        }
    }
}
