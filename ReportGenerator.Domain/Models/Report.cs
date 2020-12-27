using ReportGenerator.Domain.Enums;

namespace ReportGenerator.Domain.Models
{
    public class Report<TData>
    {
        public string Name { get; }

        public string FileName { get; }

        public FileType FileType { get; }

        public TData Data { get; }

        public Report(
            string name,
            string fileName,
            FileType fileType,
            TData data)
        {
            Name = name;
            FileName = fileName;
            FileType = fileType;
            Data = data;
        }
    }
}