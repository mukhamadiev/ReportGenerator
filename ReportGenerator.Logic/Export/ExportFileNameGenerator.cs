using ReportGenerator.Domain.Enums;
using ReportGenerator.Logic.Extensions;

namespace ReportGenerator.Logic.Export
{
    public class ExportFileNameGenerator : IExportFileNameGenerator
    {
        public string Generate(string fileName, FileType fileType) => $"{fileName}.{fileType.GetFileExtension()}";
    }
}