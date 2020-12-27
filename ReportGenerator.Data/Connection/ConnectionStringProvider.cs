using Microsoft.Extensions.Options;
using ReportGenerator.Data.Options;

namespace ReportGenerator.Data.Connection
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IOptions<DataOptions> _options;

        public ConnectionStringProvider(IOptions<DataOptions> options)
        {
            _options = options;
        }

        public string GetConnectionString() => _options.Value.ConnectionString;
    }
}