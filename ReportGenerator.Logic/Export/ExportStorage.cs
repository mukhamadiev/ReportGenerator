using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ReportGenerator.Logic.Options;
using ReportGenerator.Logic.Utils;

namespace ReportGenerator.Logic.Export
{
    public class ExportStorage : IExportStorage
    {
        private readonly IOptions<LogicOptions> _options;

        public ExportStorage(IOptions<LogicOptions> options)
        {
            _options = options;
        }

        public async Task SaveFileAsync(byte[] content, string fileName)
        {
            var filePath = Path.Combine(_options.Value.ExportDirectory, fileName);

            FileUtils.EnsureDirectory(filePath);

            await using var fileStream = File.Create(filePath);

            await fileStream.WriteAsync(content);
        }
    }
}