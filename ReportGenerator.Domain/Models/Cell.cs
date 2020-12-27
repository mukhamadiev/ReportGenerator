namespace ReportGenerator.Domain.Models
{
    public class Cell
    {
        public static readonly Cell Empty = new Cell(default);

        public string Value { get; }

        public Cell(string value)
        {
            Value = value;
        }
    }
}