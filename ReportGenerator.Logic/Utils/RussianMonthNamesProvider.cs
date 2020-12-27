using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ReportGenerator.Logic.Utils
{
    public class RussianMonthNamesProvider
    {
        private const string RussianCulture = "ru-RU";

        private readonly IReadOnlyList<string> _monthNames;

        public RussianMonthNamesProvider()
        {
            const int totalMonths = 12;
            _monthNames = Enumerable.Range(0, totalMonths)
                                    .Select(x => CultureInfo.CreateSpecificCulture(RussianCulture).DateTimeFormat.MonthNames[x])
                                    .ToArray();
        }

        public string Get(int index) => _monthNames[index];
    }
}