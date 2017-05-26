using Csv.Types.Write;

namespace Csv.Write.CsvWriter
{
    public interface ICsvWriter
    {
        CsvRow NewRow();
        void Write();
    }
}