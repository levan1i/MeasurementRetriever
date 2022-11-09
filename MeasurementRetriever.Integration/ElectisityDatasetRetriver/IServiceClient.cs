using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Integration.ElectisityDatasetRetriver
{
    public interface IServiceClient
    {
         Task<IEnumerable<Measurement>> Get(string datasetUrl,string type);
    }
}
