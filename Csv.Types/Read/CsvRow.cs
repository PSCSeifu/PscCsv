using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types.Read
{
    public class CsvRow
    {
        private readonly List<CsvCol> _Cols;

        public CsvRow()
        {
            this._Cols = new List<CsvCol>();
        }

        public CsvCol GetCol(string header)
        {
            return _Cols.Where(x => x.GetHeader() == header).SingleOrDefault();                        
        }

        public string ToLine()
        {
            var line = "";
            foreach (var item in this._Cols)
            {
                line += $"{item.GetValue()},";
            }
            line += Environment.NewLine;
            return line;
        }

        public  CsvRow NewRow(string valueLine, string headerLine)
        {
            var values = valueLine.Split(',').ToList();
            var headers = headerLine.Split(',').ToList();
            for (int i = 0; i < values.Count; i++)
            {
                _Cols.Add(new CsvCol(headers[i], values[i]));
            }
            return this;
        }
    }

    
}
