using MeasurementRetriever.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementRetriever.Service.BacgroundTasks
{
    static class FinishJobStat
    {
        public static bool isEnabled { get; set; } = true;
    }

    /// <summary>
    /// Service for retrive data
    /// </summary>
    internal class DatasetRetriverJob : BackgroundService
    {
        private readonly TimeSpan _period = TimeSpan.FromMinutes(1);
        private readonly ILogger<DatasetRetriverJob> _logger;
        private readonly IServiceScopeFactory _factory;



        public DatasetRetriverJob(
            ILogger<DatasetRetriverJob> logger,
            IServiceScopeFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Job DatasetRetriverJob start");
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (
                !stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    if (FinishJobStat.isEnabled)
                    {
                        FinishJobStat.isEnabled = false;
                        await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                        IMeasurementService _service = asyncScope.ServiceProvider.GetRequiredService<IMeasurementService>();


                        await _service.ProcessData();




                        FinishJobStat.isEnabled = true;
                        _logger.LogInformation("Job DatasetRetriverJob End");
                    }
                    else
                    {
                        _logger.LogInformation(
                            "Skipped DatasetRetriverJob");
                    }

                }
                catch (Exception ex)
                {
                    FinishJobStat.isEnabled = true;
                    _logger.LogError(
                        $"Failed to execute DatasetRetriverJob with exception message {ex.Message}");
                }
            }
        }
    }
}
