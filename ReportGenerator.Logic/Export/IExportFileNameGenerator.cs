using ReportGenerator.Domain.Enums;

namespace ReportGenerator.Logic.Export
{
    public interface IExportFileNameGenerator
    {
        string Generate(string fileName, FileType fileType);
    }
}