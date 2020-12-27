using System;
using ReportGenerator.Domain.Enums;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic.Export.Csv;

namespace ReportGenerator.Logic.Export.Table
{
    public class TableDataDocumentEngineFactory : IDocumentEngineFactory<TableData>
    {
        private readonly CsvDocumentEngine<TableData> _csvDocumentEngine;

        public TableDataDocumentEngineFactory(CsvDocumentEngine<TableData> csvDocumentEngine)
        {
            _csvDocumentEngine = csvDocumentEngine;
        }

        public IDocumentEngine<TableData> Create(FileType fileType)
        {
            return fileType switch
                   {
                       FileType.Csv => _csvDocumentEngine,
                       _ => throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null)
                   };
        }
    }
}