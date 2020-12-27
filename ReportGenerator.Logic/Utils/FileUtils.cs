using System.IO;

namespace ReportGenerator.Logic.Utils
{
    public static class FileUtils
    {
        public static void EnsureDirectory(string fileName)
        {
            var directoryName = Path.GetDirectoryName(fileName);

            if (string.IsNullOrWhiteSpace(directoryName))
                return;

            if (Directory.Exists(directoryName))
                return;

            Directory.CreateDirectory(directoryName);
        }
    }
}