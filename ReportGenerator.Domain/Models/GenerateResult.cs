namespace ReportGenerator.Domain.Models
{
    public class GenerateResult
    {
        public byte[] Content { get; }

        public GenerateResult(byte[] content)
        {
            Content = content;
        }
    }
}