using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReportGenerator.Logic;

namespace ReportGenerator.Host
{
    public class Application : BackgroundService
    {
        private readonly ILogger<Application> _logger;
        private readonly CohortReportExample _cohortReportExample;

        public Application(ILogger<Application> logger, CohortReportExample cohortReportExample)
        {
            _logger = logger;
            _cohortReportExample = cohortReportExample;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Application starting");

            await StartAsync();

            _logger.LogInformation("Application started");
        }

        private async Task StartAsync()
        {
            await _cohortReportExample.RunAsync();
        }
    }
}