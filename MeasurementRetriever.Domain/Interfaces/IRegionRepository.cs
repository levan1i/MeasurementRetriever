using MeasurementRetriever.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Domain.Interfaces
{
    public interface IRegionRepository : IGenericRepository<Region>
    {
         Task<Region> Search(string regionName);
   
    }
}
