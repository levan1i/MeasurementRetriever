using MeasurementRetriever.Integration.ElectisityDatasetRetriver;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;

namespace MeasurementRetriever.Integration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIntegrations(this IServiceCollection services)
        {

            services.AddHttpClient<IServiceClient, ServiceClient>();

            return services;
        }
    }
}
