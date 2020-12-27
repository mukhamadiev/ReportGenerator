using ReportGenerator.Domain.Enums;

namespace ReportGenerator.Logic.Export
{
    public interface IDocumentEngineFactory<TData>
    {
        IDocumentEngine<TData> Create(FileType fileType);
    }
}