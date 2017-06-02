using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types.Write
{
    public class CsvRow
    {
        private readonly List<string> _Cols;

        public CsvRow()
        {
            this._Cols = new List<string>();
        }

        public void AddCol(string data)
        {
            _Cols.Add(data);
        }

        public string ToLine() => ToLine(',', char.MinValue, "");

        public string ToLine(char separator) => ToLine(separator, char.MinValue, "");

        public string ToLine(char separator, char quote)  => ToLine(separator, quote, "");

        public string ToLine(char separator, char quote, string endOfLine)
        {
            if ((int)separator == 0) separator = ',';
            if ((int)quote == 0) quote = char.MinValue;

            StringBuilder line = new StringBuilder();
            foreach (var item in this._Cols)
            {
                if (line.Length != 0) line.Append(separator);
                if ((int)quote != 0)
                    line.Append($"{quote}{item}{quote}");
                else
                    line.Append($"{item}");
            }
            return (string.IsNullOrEmpty(endOfLine)) ?
                line.ToString() :
                line.Append(endOfLine).ToString();
        }
        
    }
}
