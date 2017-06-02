using Csv.Types.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Validate.Write
{
    public interface IWriteValidator
    {
        bool Validate(IReadOnlyList<CsvRow> rows);
        bool Validate(IReadOnlyList<CsvRow> rows, char separator, char quote, string endOfLine);
    }
}
