using MeasurementRetriever.Common.Extentions;
using MeasurementRetriever.Common.Pagination;
using MeasurementRetriever.Domain.Interfaces;
using MeasurementRetriever.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Repository
{
    internal class MeasurementRepository : Genericrepository<AgregatedMeasurment>, IMeasurmentRepository
    {
        ILogger<MeasurementRepository> _logger;
        public MeasurementRepository(MeasurementRetrieverDbContext context, ILogger<MeasurementRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public Task<PagedResult<AgregatedMeasurment>> Get(int page, int pageSize)
        {
            var data = _context.AgregatedMeasurments.Include(x=>x.Region).OrderByDescending(x=>x.MeasurmentId).GetPagedResultAsync(page, pageSize);
            return data;
        }

        public async Task<bool> SaveAgregatedMeasurements(IEnumerable<AgregatedMeasurment> measurments)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {

                _context.DatasetInfo.FirstOrDefault(x => x.Id == measurments.First().DatasetId).StatusCode = "Processed";
                try
                {



                    _context.AgregatedMeasurments.AddRange(measurments);



                    await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {

                    await dbContextTransaction.RollbackAsync();
                    _logger.LogError($"Error On SaveAgregatedMeasurements Service:{ex.Message}");
                    return false;
                }
            }
        }
    }
}
