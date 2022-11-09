using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Service.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service.Abstractions
{
    public interface IMeasurementService
    {
         Task<PagedResult<AgregatedMeasurmentDto>> Get(int Page, int PageSize);
        Task ProcessData();
    }
}
