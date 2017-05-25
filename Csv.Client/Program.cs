using Csv.IO.CsvRead;
using Csv.Read.CsvReader;
using Csv.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
            Console.WriteLine("--Done--");
            Console.ReadLine();
        }

        private static void Read()
        {
           var provider = new FileCsvProvider(@"C:\Projects\PSC\Data0.csv");

            CsvReader reader = CsvReader.Create(provider);

            reader.Read(); 

           
            foreach (var row in reader.GetRows())
            {
                //row.GetCol(0)
                var data = row.GetCol("Header1");
                Console.WriteLine($" -Header1 - {data.GetHeader()}");
                Console.WriteLine($" -Value   - {data.GetValue()}");
                Console.WriteLine($" -RowLine - {row.ToLine()}");                
            }
            
        }

    }
}
