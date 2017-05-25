using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types.Read
{
    public class CsvCol
    {
        private readonly string _Header;
        private readonly string _ColValue;

        public CsvCol()
        {
            this._Header = "";
            this._ColValue = "";
        }

        public CsvCol(string header, string value)
        {
            this._Header = header;
            this._ColValue =value;
        }

        public string GetHeader()
        {
            return this._Header;
        }
                

        public string GetValue()
        {
            return this._ColValue;
        }

        
    }
}
