using System.Collections.Generic;

namespace ReportGenerator.Domain.Models
{
    public class TableData
    {
        public IReadOnlyList<Row> Rows { get; }

        public TableData(IReadOnlyList<Row> rows)
        {
            Rows = rows;
        }
    }
}