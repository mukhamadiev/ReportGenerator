using System.Collections;
using System.Collections.Generic;

namespace ReportGenerator.Domain.Models
{
    public class Row : IReadOnlyList<Cell>
    {
        private readonly IReadOnlyList<Cell> _cells;

        public int Count => _cells.Count;

        public Cell this[int index] => _cells[index];

        public Row(IReadOnlyList<Cell> cells)
        {
            _cells = cells;
        }

        public IEnumerator<Cell> GetEnumerator() => _cells.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}