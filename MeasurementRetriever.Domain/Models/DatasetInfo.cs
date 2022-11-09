using System;
using System.Collections.Generic;
using System.Text;

namespace MeasurementRetriever.Domain.Models
{
    public class DatasetInfo
    {

        public long Id { get; set; }    
        public string Url { get;set; }
        public string  StatusCode { get; set; }
        public string Type { get; set; }
        public string ObjectTypes { get; set; }
        public DateTime CreateDate { get; set; }
        public string? OperationMessage { get; set; }

    }
}
