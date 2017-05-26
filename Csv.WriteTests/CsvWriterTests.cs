using Csv.IO.CsvWrite;
using Csv.Types.Write;
using Csv.Write.CsvWriter;
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
        #endregion

        [Fact]
        public void UoW_InitialCondition_ExpectedResult()
        {
            //Arrange
            CsvWriter writer = CsvWriter.Create(provider.Object);
            var row = writer.NewRow();
            row.AddCol("data1");
            row.AddCol("data2");
            row.AddCol("data3");
            rows.Add(row);

            //Act
            writer.Write();

            //Assert
            //provider.Object.Write(rows).
        }
    }
}
