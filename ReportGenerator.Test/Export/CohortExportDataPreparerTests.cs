using System;
using System.Threading.Tasks;
using NUnit.Framework;
using ReportGenerator.Domain.Models;
using ReportGenerator.Logic.Export.Cohort;
using ReportGenerator.Logic.Utils;

namespace ReportGenerator.Test.Export
{
    [TestFixture]
    public class CohortExportDataPreparerTests
    {
        [Test]
        public async Task ShouldPrepare()
        {
            var cohortReportData = GenerateCohortReportData();

            var monthNamesProvider = new RussianMonthNamesProvider();
            var cohortExportDataPreparer = new CohortExportDataPreparer(monthNamesProvider);

            var exportData = await cohortExportDataPreparer.PrepareAsync(cohortReportData);

            var expectation = new[,]
                              {
                                  {"3", "1", "1", "1"},
                                  {null, "1", "0", "1"},
                                  {null, null, "1", "0"},
                                  {null, null, null, "1"}
                              };

            for (var x = 0; x < expectation.GetLength(0); x++)
            {
                for (var y = 0; y < expectation.GetLength(1); y++)
                {
                    var expected = expectation[x, y];

                    const int rowIndexCorrection = 2;
                    const int columnIndexCorrection = 1;
                    var actual = exportData.Data.Rows[x + rowIndexCorrection][y + columnIndexCorrection].Value;

                    Assert.AreEqual(
                        expected: expected,
                        actual: actual,
                        message: "x:{0} y:{1}",
                        x,
                        y);
                }
            }
        }

        private static CohortReportData GenerateCohortReportData()
        {
            const int year = 2020;
            var month1 = new DateTime(year, 1, 1);
            var month2 = new DateTime(year, 2, 1);
            var month3 = new DateTime(year, 3, 1);
            var month4 = new DateTime(year, 4, 1);

            var orders = new[]
                         {
                             new Order("А", month1),
                             new Order("А", month1),
                             new Order("Б", month1),
                             new Order("В", month1),
                             new Order("А", month2),
                             new Order("А", month2),
                             new Order("Г", month2),
                             new Order("Б", month3),
                             new Order("Д", month3),
                             new Order("Д", month3),
                             new Order("Е", month4),
                             new Order("Г", month4),
                             new Order("Г", month4),
                             new Order("В", month4)
                         };

            return new CohortReportData(year, orders);
        }
    }
}