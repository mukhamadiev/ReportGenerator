using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic.Utils;

namespace ReportGenerator.Logic.Export.Cohort
{
    public class CohortExportDataPreparer : IExportDataPreparer<TableData, CohortReportData>
    {
        private readonly RussianMonthNamesProvider _monthNamesProvider;

        public CohortExportDataPreparer(RussianMonthNamesProvider monthNamesProvider)
        {
            _monthNamesProvider = monthNamesProvider;
        }

        public Task<ExportData<TableData>> PrepareAsync(CohortReportData reportData)
        {
            var values = PrepareValues(reportData.Orders);

            var tableData = PrepareTableData(reportData.Year, values);

            return Task.FromResult(new ExportData<TableData>(tableData));
        }

        private static string[,] PrepareValues(IReadOnlyCollection<Order> orders)
        {
            var customersByMonth = orders
                                   .GroupBy(x => x.DateAdded.Month)
                                   .ToDictionary(x => x.Key, x => x.Select(g => g.PhoneNumber).ToHashSet());

            const int totalMonths = 12;
            var uniqueCustomers = new HashSet<string>();
            var values = new string [totalMonths, totalMonths];
            for (var currentMonthIndex = 0; currentMonthIndex < totalMonths; currentMonthIndex++)
            {
                if (!customersByMonth.TryGetValue(currentMonthIndex + 1, out var currentMonthCustomers))
                    continue;

                var currentMonthUniqueCustomers = currentMonthCustomers
                                                  .Where(x => !uniqueCustomers.Contains(x))
                                                  .ToArray();

                uniqueCustomers.UnionWith(currentMonthUniqueCustomers);

                for (var nextMonthIndex = currentMonthIndex; nextMonthIndex < totalMonths; nextMonthIndex++)
                {
                    if (!customersByMonth.TryGetValue(nextMonthIndex + 1, out var nextCustomers))
                        continue;

                    var count = nextCustomers.Count(x => currentMonthUniqueCustomers.Contains(x));

                    values[currentMonthIndex, nextMonthIndex] = count.ToString();
                }
            }

            return values;
        }

        private TableData PrepareTableData(int year, string[,] values)
        {
            const int rowsCount = 14;
            const int columnsCount = 13;

            var rows = new List<Row>(rowsCount);
            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                var cells = new List<Cell>(columnsCount);
                for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {
                    switch (rowIndex)
                    {
                        case 0 when columnIndex == 1:
                            cells.Add(new Cell($"{year} г."));
                            break;
                        case 0:
                        case 1 when columnIndex == 0:
                            cells.Add(Cell.Empty);
                            break;
                        case 1:
                        {
                            var monthName = _monthNamesProvider.Get(columnIndex - 1);
                            cells.Add(new Cell(monthName));
                            break;
                        }
                        default:
                        {
                            if (columnIndex == 0)
                            {
                                var monthName = _monthNamesProvider.Get(rowIndex - 2);
                                cells.Add(new Cell(monthName));
                            }
                            else
                            {
                                var value = values[rowIndex - 2, columnIndex - 1];
                                cells.Add(new Cell(value));
                            }

                            break;
                        }
                    }
                }

                rows.Add(new Row(cells));
            }

            return new TableData(rows);
        }
    }
}