namespace ReportGenerator.Domain.Models
{
    public class ExportData<TData>
    {
        public TData Data { get; }

        public ExportData(TData data)
        {
            Data = data;
        }
    }
}