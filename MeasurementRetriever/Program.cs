using MeasurementRetriever.API.Extentions;
using MeasurementRetriever.Integration;
using MeasurementRetriever.Repository;
using MeasurementRetriever.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddRepository(builder.Configuration.GetConnectionString("Default"));
builder.Services.AddServices();
builder.Services.AddIntegrations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseStaticFiles();
    app.UseSwaggerUI(
      c =>
      {
       
          c.InjectStylesheet("/swagger-ui/custom.css");

      }
      );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
