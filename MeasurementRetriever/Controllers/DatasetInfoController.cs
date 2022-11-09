using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Service.Abstractions;
using MeasurementRetriever.Service.Abstractions.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeasurementRetriever.API.Controllers
{
    [Route("api/datasetinfo")]
    [ApiController]
    public class DatasetInfoController : ControllerBase
    {
        private readonly IDatasetInfoService _datasetInfoService;

        public DatasetInfoController(IDatasetInfoService datasetInfoService)
        {
            _datasetInfoService = datasetInfoService;
        }
        /// <summary>
        /// Get created datasets
        /// </summary>     
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public Task<PagedResult<DatasetInfoDto>> Get(int page = 1, int pageSize = 10)
        {
            return _datasetInfoService.Get(page, pageSize);
        }

        /// <summary>
        /// Create dataset record in db
        /// </summary>
        ///  <remarks>
        /// Datasets are automatically processed by background job
        /// 
        /// Example:
        /// {
        ///
        ///   "url": "https://data.gov.lt/dataset/1975/download/10766/2022-05.csv",
        ///  "type": "Url"
        ///  }
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
    [HttpPost()]
        public Task<DatasetInfoDto> Post(DatasetInfoDto data)
        {
            return _datasetInfoService.Create(data);
        }
    }
}
