using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Service.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service.Abstractions
{
    public interface IDatasetInfoService
    {
        Task<DatasetInfoDto>Create(DatasetInfoDto datasetDto);
        Task<PagedResult<DatasetInfoDto>> Get(int page,int pageSize);
    }
}
