using Csv.Types.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Validate.Read
{
    public interface IReadValidator
    {
        bool Validate(IReadOnlyList<CsvRow> rows);
    }
}
