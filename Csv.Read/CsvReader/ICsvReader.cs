using Csv.Types;

namespace Csv.Read.CsvReader
{
    public interface ICsvReader
    {
        string GetLine(int index);
        CsvRow NewRow();
        CsvRow NewRow(string rowData);
        void Read();
    }
}