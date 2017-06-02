using Csv.IO.CsvWrite;
using Csv.Types.Write;
using Csv.Write.CsvWriter;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.WriteTests
{
    public class CsvWriterTests
    {
        #region " SET UP "
        Mock<ICsvOutputProvider> provider = new Mock<ICsvOutputProvider>();
        List<CsvRow> rows = new List<CsvRow>();

        public class StringCsvOutputProvider : ICsvOutputProvider
        {
            public string csvOutput { get; set; } = "";

            public void Write(IReadOnlyList<CsvRow> rows)
            => Write(rows, ',', char.MinValue, "");

            public void Write(IReadOnlyList<CsvRow> rows, char separator)
            => Write(rows, separator, char.MinValue, "");

            public void Write(IReadOnlyList<CsvRow> rows, char separator, char quote)
             => Write(rows, separator, quote, "");

            public void Write(IReadOnlyList<CsvRow> rows, char separator, char quote, string endofLine)
            {
                foreach (var row in rows)
                    csvOutput += row.ToLine(separator, quote, endofLine);                
            }
        }
        #endregion

        [Fact]
        public void NewRow_AddsRowsInSequence_RowsAdded_InOrder()
        {
            //Arrange
            StringCsvOutputProvider prov = new StringCsvOutputProvider();
            CsvWriter writer = CsvWriter.Create(prov);
            CsvRow row = writer.NewRow();
            row.AddCol("data11");
            row.AddCol("data12");
            row.AddCol("data13");
            CsvRow row2 = writer.NewRow();
            row2.AddCol("data21");
            row2.AddCol("data22");
            row2.AddCol("data23");
            string expected = $"data11,data12,data13data21,data22,data23";

            //Act
            writer.Write();

            //Assert
            prov.csvOutput.Should().Be(expected);
        }
    }
}
