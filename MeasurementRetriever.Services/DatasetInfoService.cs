using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Interfaces;
using MeasurementRetriever.Service.Abstractions;
using MeasurementRetriever.Service.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service
{
    public class DatasetInfoService : IDatasetInfoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DatasetInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DatasetInfoDto> Create(DatasetInfoDto datasetDto)
        {
            var ent =await _unitOfWork.DatasetRepository.Add(datasetDto.MapToDatasetInfo());
             _unitOfWork.Complete();
            return ent.MapToDatasetInfoDto();
        }

        public async Task<PagedResult<DatasetInfoDto>> Get(int page,int pageSize)
        {

            var res = await _unitOfWork.DatasetRepository.Get(page, pageSize);
            return res.MapToPagedDatasetInfoDto();
            
        }
    }
}
