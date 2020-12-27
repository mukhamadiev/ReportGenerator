using System.Data;

namespace ReportGenerator.Data.Connection
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}