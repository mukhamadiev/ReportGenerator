using System.Threading.Tasks;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Logic.Export
{
    public interface IReportExporter<TData>
    {
        Task ExportAsync(Report<TData> report);
    }
}