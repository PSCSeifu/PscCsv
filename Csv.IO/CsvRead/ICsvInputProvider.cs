using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.IO.CsvRead
{
    public interface ICsvInputProvider
    {
        List<string> Read();
        List<string> Read(string endOfLine);
    }
}
