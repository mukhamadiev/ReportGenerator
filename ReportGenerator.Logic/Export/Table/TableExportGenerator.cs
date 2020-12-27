using System.Threading.Tasks;
using ReportGenerator.Domain.Enums;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Logic.Export.Table
{
    public class TableExportGenerator : IExportGenerator<TableData>
    {
        private readonly IDocumentEngineFactory<TableData> _documentEngineFactory;

        public TableExportGenerator(IDocumentEngineFactory<TableData> documentEngineFactory)
        {
            _documentEngineFactory = documentEngineFactory;
        }

        public Task<GenerateResult> GenerateAsync(ExportData<TableData> exportData, FileType fileType)
        {
            var documentEngine = _documentEngineFactory.Create(fileType);
            return documentEngine.GenerateAsync(exportData);
        }
    }
}