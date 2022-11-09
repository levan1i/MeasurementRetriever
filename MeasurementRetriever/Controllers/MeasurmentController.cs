using MeasurementRetriever.Common.Models;
using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Service.Abstractions;
using MeasurementRetriever.Service.Abstractions.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MeasurementRetriever.API.Controllers
{
    [Route("api/measurments")]
    [ApiController]
    public class MeasurmentController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurmentController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }


        /// <summary>
        /// Get Paged Agregated Measurements 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(PagedResult<AgregatedMeasurmentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultBase), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultBase), (int)HttpStatusCode.InternalServerError)]
        public async Task<PagedResult<AgregatedMeasurmentDto>> Get(int page=1, int pagesize=10)
        {
            
            return await _measurementService.Get(page, pagesize);
        }
    }
}
