using Csv.Types.Write;
using System.Collections.Generic;

namespace Csv.IO.CsvWrite
{
    public interface ICsvOutputProvider
    {
        void Write(IReadOnlyList<CsvRow> rows);
        void Write(IReadOnlyList<CsvRow> rows, char separator);
        void Write(IReadOnlyList<CsvRow> rows, char separator, char quote);
        void Write(IReadOnlyList<CsvRow> rows, char separator, char quote, string endofLine);
    }
}
