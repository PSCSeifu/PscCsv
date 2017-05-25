using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csv.Types.Write;
using System.IO;

namespace Csv.IO.CsvWrite
{
    public class FileCsvOutputProvider : ICsvOutputProvider
    {
        private readonly string _FileName;

        public FileCsvOutputProvider(string filename)
        {
            this._FileName = filename;
        }

        public void Write(IReadOnlyList<CsvRow> rows)
        {
            using (StreamWriter sw = new StreamWriter(_FileName))
            {
                foreach (var row in rows)
                {
                    sw.WriteLine(row.ToLine());
                }
            }
        }
    }
}
