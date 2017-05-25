using Csv.Types.Write;
using System.Collections.Generic;

namespace Csv.IO.CsvWrite
{
    public interface ICsvOutputProvider
    {
        void Write(IReadOnlyList<CsvRow> rows);
    }
}
