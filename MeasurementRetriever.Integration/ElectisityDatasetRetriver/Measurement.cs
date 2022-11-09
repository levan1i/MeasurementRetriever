using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Integration.ElectisityDatasetRetriver
{
    public class Measurement
    {
        public string TINKLAS { get; set; } 
        public string OBT_PAVADINIMAS { get; set; }
        public string OBJ_GV_TIPAS { get; set; }
        public long OBJ_NUMERIS { get; set; }
        public decimal? PPlus { get; set; }
        public decimal? PMinus { get; set; }
        public DateTime PL_T { get; set; }


    }
}
