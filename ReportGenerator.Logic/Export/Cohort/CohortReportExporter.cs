using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Logic.Export.Cohort
{
    public class CohortReportExporter : IReportExporter<CohortReportData>
    {
        private readonly IExportDataPreparer<TableData, CohortReportData> _exportDataPreparer;
        private readonly IExportGenerator<TableData> _exportGenerator;
        private readonly IExportFileNameGenerator _exportFileNameGenerator;
        private readonly IExportStorage _exportStorage;
        private readonly ILogger<CohortReportExporter> _logger;

        public CohortReportExporter(
            IExportDataPreparer<TableData, CohortReportData> exportDataPreparer,
            IExportGenerator<TableData> exportGenerator,
            IExportFileNameGenerator exportFileNameGenerator,
            IExportStorage exportStorage,
            ILogger<CohortReportExporter> logger)
        {
            _exportDataPreparer = exportDataPreparer;
            _exportGenerator = exportGenerator;
            _exportFileNameGenerator = exportFileNameGenerator;
            _exportStorage = exportStorage;
            _logger = logger;
        }

        public async Task ExportAsync(Report<CohortReportData> report)
        {
            try
            {
                _logger.LogInformation("Start report {ReportName}", report.Name);

                var exportData = await _exportDataPreparer.PrepareAsync(report.Data);
                var generateResult = await _exportGenerator.GenerateAsync(exportData, report.FileType);
                var fileName = _exportFileNameGenerator.Generate(report.FileName, report.FileType);
                await _exportStorage.SaveFileAsync(generateResult.Content, fileName);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error report {ReportName}", report.Name);
            }
            finally
            {
                _logger.LogInformation("Complete report {ReportName}", report.Name);
            }
        }
    }
}