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
        private readonly string _Data;

        public CsvCol()
        {
            this._Header = "";
            this._Data = "";
        }

        public CsvCol(string header, string value)
        {
            this._Header = header;
            this._Data = value;
        }

        public string GetHeader()
        {
            return this._Header;
        }
                

        public string GetValue()
        {
            return this._Data;
        }

        
    }
}
