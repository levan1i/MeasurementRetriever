using MeasurementRetriever.Domain.Interfaces;
using MeasurementRetriever.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Repository
{
    public class RegionRepository : Genericrepository<Region>, IRegionRepository
    {
        public RegionRepository(MeasurementRetrieverDbContext context) : base(context)
        {
        }

        public Task<Region> Search(string regionName)
        {
            return _context.Regions.FirstOrDefaultAsync(r => r.RegionName == regionName);      
        }
    }
}
