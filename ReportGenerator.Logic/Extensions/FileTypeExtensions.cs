using ReportGenerator.Domain.Enums;

namespace ReportGenerator.Logic.Extensions
{
    public static class FileTypeExtensions
    {
        public static string GetFileExtension(this FileType fileType) => fileType.ToString().ToLowerInvariant();
    }
}