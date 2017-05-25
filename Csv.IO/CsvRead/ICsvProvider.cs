using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.IO.CsvRead
{
    public interface ICsvProvider
    {
        List<string> Read();
    }
}
