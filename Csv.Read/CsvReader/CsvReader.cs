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
        private readonly ICsvProvider _Provider;

        public CsvReader(ICsvProvider provider)
        {
            this._Rows = new List<CsvRow>();
            this._Provider = provider;
        }

        

        public static CsvReader Create(ICsvProvider read)
        {
            return new CsvReader(read);
        }

        public static CsvReader Create(FileCsvProvider fileProvider)
        {
            return new CsvReader(fileProvider);
        }
               
        public List<CsvRow> GetRows()
        {
            return _Rows;
        }

        public void Read()
        {
           List<string> csvLines =  this._Provider.Read();
            var header = csvLines[0];
            if(csvLines != null)
            {
                foreach (var line in csvLines)
                {
                    _Rows.Add(NewRow(line,header));
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
