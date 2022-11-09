using System;
using System.Collections.Generic;
using System.Text;

namespace MeasurementRetriever.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

      
        IMeasurmentRepository MeasurmentRepository { get; }
        IDatasetRepository DatasetRepository { get; }
        IRegionRepository RegionRepository { get; }

  
        int Complete();
    }
}
