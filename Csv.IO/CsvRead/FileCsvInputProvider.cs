using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.IO.CsvRead
{
    public class FileCsvInputProvider : ICsvInputProvider
    {
        private readonly string _FileName;

        public FileCsvInputProvider(string filename)
        {
            this._FileName = filename;
        }
        

        public List<string> Read()
        {
            List<string> csvLines = new List<string>();
            using (StreamReader sr = new StreamReader(this._FileName))
            {
                while (!sr.EndOfStream)
                {
                    csvLines.Add(sr.ReadLine());
                }
            }
            return csvLines;
        }
    }
}
