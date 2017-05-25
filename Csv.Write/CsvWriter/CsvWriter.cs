using Csv.IO.CsvWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types.Write;

namespace Csv.Write.CsvWriter
{
    public class CsvWriter
    {
        private readonly  ICsvOutputProvider _Provider;
        private readonly List<CsvRow> _Rows;

        public CsvWriter(ICsvOutputProvider provider)
        {
            this._Provider = provider;
            this._Rows = new List<CsvRow>();
        }
        
        public static CsvWriter Create(ICsvOutputProvider write)
        {
            return new CsvWriter(write);
        }

        public static CsvWriter Create(string filename)
        {
            return new CsvWriter(new FileCsvOutputProvider(filename));
        }

        public CsvRow NewRow()
        {
            var row = new CsvRow();
            _Rows.Add(row);
            return row;
        }

        public void Write()
        {
            this._Provider.Write(this._Rows);
        }
    }
}
