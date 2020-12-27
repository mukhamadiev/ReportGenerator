using System.Linq;
using System.Text;

namespace ReportGenerator.Logic.Utils
{
    public class Encoder
    {
        private readonly byte[] _preamble;

        public Encoder()
        {
            _preamble = Encoding.UTF8.GetPreamble();
        }

        public byte[] GetBytes(string content) => _preamble.Concat(Encoding.UTF8.GetBytes(content)).ToArray();
    }
}