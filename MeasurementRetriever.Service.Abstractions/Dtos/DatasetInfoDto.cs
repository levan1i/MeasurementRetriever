using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service.Abstractions.Dtos
{
    public class DatasetInfoDto 
    {
        public long Id { get; set; }    
        public string Url { get; set; }
        public string? StatusCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Type { get; set; }
       
    }
}
