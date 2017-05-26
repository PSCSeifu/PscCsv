﻿using System;
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

        public string ToLine()
        {
            StringBuilder line = new StringBuilder ();
            foreach (var item in this._Cols)
            {               
                line.Append( $"{item},");
            }
            return line.ToString()
                        .Substring(0, line.Length - 1);
        }

        public void AddCol(string data)
        {
            _Cols.Add(data);
        }
    }
}
