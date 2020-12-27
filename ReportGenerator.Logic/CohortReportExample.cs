using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReportGenerator.Data.Repositories;
using ReportGenerator.Domain.Enums;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic.Export;

namespace ReportGenerator.Logic
{
    public class CohortReportExample
    {
        private readonly ILogger<CohortReportExample> _logger;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IReportExporter<CohortReportData> _reportExporter;

        public CohortReportExample(
            ILogger<CohortReportExample> logger,
            IOrdersRepository ordersRepository,
            IReportExporter<CohortReportData> reportExporter)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
            _reportExporter = reportExporter;
        }

        public async Task RunAsync()
        {
            _logger.LogInformation("Start example");

            const int year = 2018;

            var orders = await _ordersRepository.GetByYearAsync(year);

            var report = new Report<CohortReportData>(
                name: $"Когортный анализ за {year} год",
                fileName: $"Когортный_анализ_{year}",
                fileType: FileType.Csv,
                data: new CohortReportData(year, orders));

            await _reportExporter.ExportAsync(report);

            _logger.LogInformation("End  example");
        }
    }
}