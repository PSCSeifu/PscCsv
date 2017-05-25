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


            string headerLine = reader.GetLine(0);

            CsvRow headerRow = reader.NewRow(headerLine);

            var header1 = headerRow.GetItem(0);
            var header2 = headerRow.GetItem(1);
            var header3 = headerRow.GetItem(2);

            Console.WriteLine($"{header1} , {header2}, {header3}");

            for (int i = 1; i < 10; i++)
            {
               
                string dataline = reader.GetLine(i);
                CsvRow dataRow = reader.NewRow(dataline);

                var item1 = dataRow.GetItem(0);
                var item2 = dataRow.GetItem(1);
                var item3 = dataRow.GetItem(2);
                Console.WriteLine($"{item1} , {item2}, {item3}");
            }
        }

    }
}
