using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Models;
using MeasurementRetriever.Service.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service
{
    public static class MapperExtention
    {
        public static AgregatedMeasurmentDto MapToAgregatedMeasurmentDto(this AgregatedMeasurment data)
        {
            return new AgregatedMeasurmentDto
            {

                Id = data.MeasurmentId,

                PMinus = data.PMinus,
                PPlus = data.PPlus,
                Region = data.Region.RegionName,
                From = data.From,
                To = data.To,
                CreateDate = data.CreateDate,

            };
        }

        public static AgregatedMeasurment MapToAgregatedMeasurment(this AgregatedMeasurmentDto data,Region region,long datasetId)
        {
            return new AgregatedMeasurment
            {

                MeasurmentId = data.Id,

                PMinus = data.PMinus,
                PPlus = data.PPlus,
                Region = region,
                From = data.From,
                To = data.To,
                CreateDate = DateTime.Now,
                DatasetId=datasetId

            };
        }


        public static PagedResult<AgregatedMeasurmentDto> MapToPagedAgregatedMeasurmentDto(this PagedResult<AgregatedMeasurment> data)
        {
            return new PagedResult<AgregatedMeasurmentDto>()
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = data.Results.Select(x => x.MapToAgregatedMeasurmentDto()).ToList()
            };
        }

        public static DatasetInfo MapToDatasetInfo(this DatasetInfoDto data)
        {
            return new DatasetInfo()
            {
                CreateDate = DateTime.Now,
                Id = data.Id,
                ObjectTypes = "Butas",
               
                StatusCode = "Created",
                Type = data.Type,
                Url = data.Url,
            };
        }

        public static DatasetInfoDto MapToDatasetInfoDto(this DatasetInfo data)
        {
            return new DatasetInfoDto()
            {
                CreateDate = data.CreateDate,
                Id = data.Id,
                StatusCode = data.StatusCode,
                Type = data.Type,
                Url = data.Url,
            };
        }



        public static PagedResult<DatasetInfoDto> MapToPagedDatasetInfoDto(this PagedResult<DatasetInfo> data)
        {
            return new PagedResult<DatasetInfoDto>()
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = data.Results.Select(x => x.MapToDatasetInfoDto()).ToList()
            };
        }

    }
}
