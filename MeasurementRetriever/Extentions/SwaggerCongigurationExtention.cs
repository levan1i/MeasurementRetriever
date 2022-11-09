namespace MeasurementRetriever.API.Extentions
{
    public static class SwaggerConfigurationExtention
    {

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments("./MeasurementRetriever.API.xml");
              
            });
            return services;

        }
    }
}
