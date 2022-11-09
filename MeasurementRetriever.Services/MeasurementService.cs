using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Interfaces;
using MeasurementRetriever.Domain.Models;
using MeasurementRetriever.Integration.ElectisityDatasetRetriver;
using MeasurementRetriever.Service.Abstractions;
using MeasurementRetriever.Service.Abstractions.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ILogger<MeasurementService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceClient _seviceClient;
        public MeasurementService(IUnitOfWork unitOfWork, IServiceClient seviceClient, ILogger<MeasurementService> logger)
        {
            _unitOfWork = unitOfWork;
            _seviceClient = seviceClient;
            _logger = logger;
        }

        public async Task<PagedResult<AgregatedMeasurmentDto>> Get(int Page, int PageSize)
        {
            var data =await _unitOfWork.MeasurmentRepository.Get(Page, PageSize);
            var result = data.MapToPagedAgregatedMeasurmentDto();
            return result;
        }

        public async Task ProcessData()
        {


            var datasetsToProcess =await _unitOfWork.DatasetRepository.GetUnprocessed();
            foreach(var datasetinfo in datasetsToProcess)
            {

                //"https://data.gov.lt/dataset/1975/download/10766/2022-05.csv"

                try
                {


                    var data = await _seviceClient.Get(datasetinfo.Url, datasetinfo.Type);
                    var agregated = await AgregateRetrivedData(data.Where(x => datasetinfo.ObjectTypes.Split(";").Any(a => a == x.OBT_PAVADINIMAS)));
                    var measurements =await AddPreparedDataToList(agregated, datasetinfo.Id);
                    var iscreated = await _unitOfWork.MeasurmentRepository.SaveAgregatedMeasurements(measurements);
                    if (!iscreated)
                    {
                        _logger.LogError("Error On ProcessData service");
                    }
                }
                catch (Exception ex)
                {
                    datasetinfo.StatusCode = "Failled";
                    datasetinfo.OperationMessage = $"An Error Has Occured See Error Message: {ex.Message}";

                    _unitOfWork.DatasetRepository.Update(datasetinfo);
                    _unitOfWork.Complete();
                    _logger.LogError(ex,"error during get data from Dataset Service");
                    throw ex;
                }
            }
          

           
        }

        public async Task<List<AgregatedMeasurment>> AddPreparedDataToList(IEnumerable<AgregatedMeasurmentDto> agregated,long datasetId)
        {
            List<AgregatedMeasurment> measurements = new List<AgregatedMeasurment>();
            foreach (var item in agregated)
            {
                measurements.Add(await PrepareProcessModel(item, datasetId));
            }
            return measurements;
        }
        private async Task<AgregatedMeasurment> PrepareProcessModel(AgregatedMeasurmentDto agregatedData,long datasetid)
        {

            var regionInfo = await _unitOfWork.RegionRepository.Search(agregatedData.Region);
            if (regionInfo == null)
            {
              var created = await _unitOfWork.RegionRepository.Add(new Domain.Models.Region()
                {
                    RegionName = agregatedData.Region
                });
                _unitOfWork.Complete();
                regionInfo = created;
            }

            return agregatedData.MapToAgregatedMeasurment(regionInfo,datasetid);
            
        }

     

        
        public async Task<IEnumerable<AgregatedMeasurmentDto>> AgregateRetrivedData(IEnumerable<Measurement> data)
        {
            var grouped = data.GroupBy(x => x.TINKLAS);
            var agregated = grouped.Select(x => new AgregatedMeasurmentDto()
            {
                To = x.Max(x=>x.PL_T),
                From = x.Min(x=>x.PL_T),
                PMinus = x.Sum(a => a.PMinus).Value,
                PPlus = x.Sum(a => a.PPlus).Value,
                Region = x.Key
            });
            return agregated;


        }
    }
}
