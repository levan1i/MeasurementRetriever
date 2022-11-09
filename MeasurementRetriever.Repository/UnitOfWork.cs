using MeasurementRetriever.Domain.Interfaces;
using System;

namespace MeasurementRetriever.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MeasurementRetrieverDbContext _context;

        public IMeasurmentRepository MeasurmentRepository { get; }

        public IDatasetRepository DatasetRepository { get; }

        public IRegionRepository RegionRepository { get; }
        public UnitOfWork(MeasurementRetrieverDbContext context, IMeasurmentRepository measurmentRepository, IDatasetRepository datasetRepository, IRegionRepository regionRepository)
        {
            _context = context;
            MeasurmentRepository = measurmentRepository;
            DatasetRepository = datasetRepository;
            RegionRepository = regionRepository;
        }


  

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
