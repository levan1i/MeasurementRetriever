using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service.Abstractions.Dtos
{
    public class AgregatedMeasurmentDto
    {
        public long Id { get; set; }    
    
        public string Region { get; set; }  
        public decimal PPlus { get; set; }   
        public decimal PMinus { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime CreateDate { get; set; }
    
    }
}
