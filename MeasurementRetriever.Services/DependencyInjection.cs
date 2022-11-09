using MeasurementRetriever.Service.Abstractions;
using MeasurementRetriever.Service.BacgroundTasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IDatasetInfoService, DatasetInfoService>();
            services.AddHostedService<DatasetRetriverJob>();

            return services;
        }
    }
}
