using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types.Write;

namespace Csv.Validate.Write
{
    public class ValidateFormat : IWriteValidator
    {
        public bool Validate(IReadOnlyList<CsvRow> rows)
        {
            if (rows == null || rows.Count == 0)
                return false;
            else
            {
                foreach (var row in rows )
                {

                }
            }
            return true;
        }

        public bool Validate(IReadOnlyList<CsvRow> rows, char separator, char quote, string endOfLine)
        {
            if (rows == null || rows.Count == 0)
                return false;
            else
            {
                foreach (var row in rows)
                {
                   
                }
            }
            return true;
        }
    }
}
