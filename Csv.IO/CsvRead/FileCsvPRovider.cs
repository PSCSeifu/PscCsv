using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.IO.CsvRead
{
    public class FileCsvProvider : ICsvProvider
    {
        private readonly string _FileName;

        public FileCsvProvider(string filename)
        {
            this._FileName = filename;
        }

        public string Read()
        {
            string data = "";
            using (StreamReader sr = new StreamReader(this._FileName))
            {                
                while (!sr.EndOfStream)
                {
                     data = sr.ReadToEnd();
                }
            }
            return data;
        }
    }
}
