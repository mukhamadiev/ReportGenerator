using System.Collections.Generic;

namespace ReportGenerator.Domain.Models
{
    public class CohortReportData
    {
        public int Year { get; }

        public IReadOnlyCollection<Order> Orders { get; }

        public CohortReportData(int year, IReadOnlyCollection<Order> orders)
        {
            Year = year;
            Orders = orders;
        }
    }
}