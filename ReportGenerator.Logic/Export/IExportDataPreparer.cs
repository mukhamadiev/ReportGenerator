using System.Threading.Tasks;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Logic.Export
{
    public interface IExportDataPreparer<TExportData, in TReportData>
    {
        Task<ExportData<TExportData>> PrepareAsync(TReportData reportData);
    }
}