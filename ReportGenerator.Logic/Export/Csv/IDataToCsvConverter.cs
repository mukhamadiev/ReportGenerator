namespace ReportGenerator.Logic.Export.Csv
{
    public interface IDataToCsvConverter<in TData>
    {
        string Convert(TData data);
    }
}