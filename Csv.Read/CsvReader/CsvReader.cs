using Csv.IO.CsvRead;
using Csv.Types.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Read.CsvReader
{
    public class CsvReader : ICsvReader
    {
        private readonly List<CsvRow> _Rows;
        private readonly ICsvInputProvider _Provider;

        public CsvReader(ICsvInputProvider provider)
        {
            this._Rows = new List<CsvRow>();
            this._Provider = provider;
        }
        
        public static CsvReader Create(ICsvInputProvider read)
        {
            return new CsvReader(read);
        }

        public static CsvReader Create(FileCsvInputProvider fileProvider)
        {
            return new CsvReader(fileProvider);
        }
               
        public List<CsvRow> GetRows()
        {
            return _Rows;
        }

        public void Read()
            => Read("");

        public void Read(string endOfLine)
        {
            List<string> csvLines = new List<string>();
            if(string.IsNullOrEmpty(endOfLine))
                this._Provider.Read(endOfLine);
            else
                this._Provider.Read();

            var header = csvLines[0];
            if (csvLines != null)
            {
                foreach (var line in csvLines)
                {
                    _Rows.Add(NewRow(line, header));
                }
            }
        }

        private CsvRow NewRow(string line, string header)
        {
            CsvRow row = new CsvRow();
            row.NewRow(line, header);
            return row;
        }
    }
}
