using System;
using System.Collections.Generic;
using System.Text;

namespace MeasurementRetriever.Domain.Models
{
    public class AgregatedMeasurment
    {
        public long MeasurmentId { get; set; }
        
        public virtual Region Region { get; set; }
    
        public decimal PPlus { get; set; }   
        public decimal PMinus { get; set; }  
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime CreateDate { get; set; }
        public long DatasetId { get; set; }

            }
}
