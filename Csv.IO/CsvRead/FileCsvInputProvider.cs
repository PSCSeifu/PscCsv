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

        public List<string> Read(string endOfLine)
        {
            List<string> csvLines = new List<string>();
            string text = "";
            string[] eol = new string[1];
            eol[0] = endOfLine;

            using (StreamReader sr = new StreamReader(this._FileName))
            {
                text = sr.ReadToEnd();
            }

            csvLines = text.Split(eol, StringSplitOptions.None).ToList();

            return csvLines;
        }
    }
}
