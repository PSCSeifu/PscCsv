using Csv.IO.CsvRead;
using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Read.CsvReader
{
    public class CsvReader : ICsvReader
    {
        private readonly ICsvProvider _Provider;
        private readonly List<CsvRow> _Rows;
        private readonly List<string> _Lines;

        public CsvReader(ICsvProvider provider)
        {
            this._Provider = provider;
            this._Rows = new List<CsvRow>();
            this._Lines = new List<string>();
        }

        public static CsvReader Create(ICsvProvider csvProvider)
        {
            return new CsvReader(csvProvider);
        }

        public static CsvReader Create(string filename)
        {
            return new CsvReader(new FileCsvProvider(filename));
        }

        public CsvRow NewRow()
        {
            var row = new CsvRow();
            _Rows.Add(row);
            return row;
        }

        public CsvRow NewRow(string rowData)
        => NewRow(rowData, ',');

        public CsvRow NewRow(string rowData, char separator)
        {
            var row = new CsvRow();
            _Rows.Add(row);
            rowData.Split(separator)
                   .ToList()
                   .ForEach(item => row.AddItem(item));
            return row;
        }

        

        public string GetLine(int index)
        {
            return _Lines[index];
        }

        public void Read()
        {           
           Read( Environment.NewLine);            
        }

        public void Read(string endOfLine)
        {
            var data = this._Provider.Read();            
            data.Split(endOfLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .ToList()
                 .ForEach(line => _Lines.Add(line));
        }
    }
}
