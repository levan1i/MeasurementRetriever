using MeasurementRetriever.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string ConnectionString)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDatasetRepository, DatasetRepository>();
      
            services.AddTransient<IMeasurmentRepository, MeasurementRepository>();
   
            services.AddTransient<IRegionRepository, RegionRepository>();

            services.AddDbContext<MeasurementRetrieverDbContext>(options => options.UseSqlServer(ConnectionString));

            return services;
        }
    }
}
