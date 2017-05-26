using System.Collections.Generic;
using Csv.Types.Read;

namespace Csv.Read.CsvReader
{
    public interface ICsvReader
    {
        List<CsvRow> GetRows();
        void Read();
    }
}