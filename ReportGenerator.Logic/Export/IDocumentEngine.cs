using System.Threading.Tasks;
using ReportGenerator.Domain.Models;

namespace ReportGenerator.Logic.Export
{
    public interface IDocumentEngine<TData>
    {
        Task<GenerateResult> GenerateAsync(ExportData<TData> exportData);
    }
}