using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic.Export.Csv;
using ReportGenerator.Logic.Options;

namespace ReportGenerator.Logic.Export.Table
{
    public class TableDataToCsvConverter : IDataToCsvConverter<TableData>
    {
        private readonly IOptions<LogicOptions> _options;

        public TableDataToCsvConverter(IOptions<LogicOptions> options)
        {
            _options = options;
        }

        public string Convert(TableData data)
        {
            var stringBuilder = new StringBuilder();
            foreach (var row in data.Rows)
            {
                stringBuilder.AppendJoin(_options.Value.CsvSeparator, row.Select(cell => cell.Value));
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}