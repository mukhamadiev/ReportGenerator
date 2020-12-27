using System.Threading.Tasks;

namespace ReportGenerator.Logic.Export
{
    public interface IExportStorage
    {
        Task SaveFileAsync(byte[] content, string fileName);
    }
}