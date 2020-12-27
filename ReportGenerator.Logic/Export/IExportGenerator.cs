using System.Threading.Tasks;
using ReportGenerator.Domain.Enums;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Logic.Export
{
    public interface IExportGenerator<TData>
    {
        Task<GenerateResult> GenerateAsync(ExportData<TData> exportData, FileType fileType);
    }
}