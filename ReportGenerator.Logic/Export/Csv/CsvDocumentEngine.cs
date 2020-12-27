using System.Threading.Tasks;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic.Utils;

namespace ReportGenerator.Logic.Export.Csv
{
    public class CsvDocumentEngine<TData> : IDocumentEngine<TData>
    {
        private readonly IDataToCsvConverter<TData> _dataToCsvConverter;
        private readonly Encoder _encoder;

        public CsvDocumentEngine(IDataToCsvConverter<TData> dataToCsvConverter, Encoder encoder)
        {
            _dataToCsvConverter = dataToCsvConverter;
            _encoder = encoder;
        }

        public Task<GenerateResult> GenerateAsync(ExportData<TData> exportData)
        {
            var content = _dataToCsvConverter.Convert(exportData.Data);

            var bytes = _encoder.GetBytes(content);

            return Task.FromResult(new GenerateResult(bytes));
        }
    }
}