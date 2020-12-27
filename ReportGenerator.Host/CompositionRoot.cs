using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReportGenerator.Data.Connection;
using ReportGenerator.Data.Options;
using ReportGenerator.Data.Repositories;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic;
using ReportGenerator.Logic.Export;
using ReportGenerator.Logic.Export.Cohort;
using ReportGenerator.Logic.Export.Csv;
using ReportGenerator.Logic.Export.Table;
using ReportGenerator.Logic.Options;
using ReportGenerator.Logic.Utils;

namespace ReportGenerator.Host
{
    public static class CompositionRoot
    {
        public static void RegisterDependencies(IServiceCollection container, HostBuilderContext hostBuilderContext)
        {
            container.AddHostedService<Application>();
            AddOptions(container, hostBuilderContext.Configuration);
            container.AddLogging();

            container.AddTransient<CohortReportExample>();
            container.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
            container.AddTransient<IDbConnectionFactory, DbConnectionFactory>();
            container.AddTransient<IOrdersRepository, OrdersRepository>();
            container.AddTransient<IExportDataPreparer<TableData, CohortReportData>, CohortExportDataPreparer>();
            container.AddTransient<IExportGenerator<TableData>, TableExportGenerator>();
            container.AddTransient<IExportStorage, ExportStorage>();
            container.AddTransient<IExportFileNameGenerator, ExportFileNameGenerator>();
            container.AddTransient<IReportExporter<CohortReportData>, CohortReportExporter>();
            container.AddTransient<IDocumentEngineFactory<TableData>, TableDataDocumentEngineFactory>();
            container.AddTransient(typeof(CsvDocumentEngine<>));
            container.AddTransient<IDataToCsvConverter<TableData>, TableDataToCsvConverter>();
            container.AddTransient<RussianMonthNamesProvider>();
            container.AddTransient<Encoder>();
        }

        private static void AddOptions(IServiceCollection container, IConfiguration configuration)
        {
            container.AddOptions();
            container.AddOptions<DataOptions>().Bind(configuration.GetSection(nameof(DataOptions)));
            container.AddOptions<LogicOptions>().Bind(configuration.GetSection(nameof(LogicOptions)));
        }
    }
}