using Csv.IO.CsvRead;
using Csv.IO.CsvWrite;
using Csv.Read.CsvReader;
using Csv.Types.Write;
using Csv.Write.CsvWriter;
using System;

namespace Csv.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeQuoteUnHappyPath();
            ///DeQuote();
            Read();
            //Write();
            Console.WriteLine("--Done--");
            Console.ReadLine();
        }

        private static void Read()
        {
           var provider = new FileCsvInputProvider(@"C:\Projects\PSC\Datax.csv");

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

        public static void Write()
        {
            var provider = new FileCsvOutputProvider(@"C:\Projects\PSC\DataC4.csv");

            CsvWriter writer = CsvWriter.Create(provider);

            CsvRow headerRow = writer.NewRow();
            headerRow.AddCol("Header1");
            headerRow.AddCol("Header2");
            headerRow.AddCol("Header3");

            for (int i = 0; i < 10; i++)
            {
                CsvRow dataRow = writer.NewRow();
                dataRow.AddCol($"first{i}");
                dataRow.AddCol($"second{i}");
                dataRow.AddCol($"third{i}");
            }

            writer.Write();
        }

        private static void DeQuote()
        {
            var valueLine = "'data1','data2','data2'";
            var headerLine = "'header1','header2','header3'";

           Csv.Types.Read.CsvRow row = new Csv.Types.Read.CsvRow();
            row.NewRow(valueLine, headerLine, ',','\'');

            var resutlHeader = row.GetCol("header1").GetHeader();
            var resultValue = row.GetCol("header1").GetValue();

            Console.WriteLine($"header => {resutlHeader}");
            Console.WriteLine($"value => {resultValue}");
        }

        private static void DeQuoteUnHappyPath()
        {
            var valueLine = "*data1*,*data2*,*data2*";
           var  headerLine = "*header1*,*header2*,*header3*";

            Csv.Types.Read.CsvRow row = new Csv.Types.Read.CsvRow();
            row.NewRow(valueLine, headerLine, ',', '\'');

            var resutlHeader = row.GetCol("*header1*").GetHeader();
            var resultValue = row.GetCol("*header1*").GetValue();

            Console.WriteLine($"header => {resutlHeader}");
            Console.WriteLine($"value => {resultValue}");
        }

       
    }
}

