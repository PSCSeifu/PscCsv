using Csv.IO.CsvRead;
using Csv.Read.CsvReader;
using Csv.Types.Read;
using FluentAssertions;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.ReaderTests
{
    public class CsvReaderTests
    {
        #region " SET UP "
        public  class MockedValues 
        {
           public  Mock<ICsvInputProvider> provider { get; set; }
            public List<string> CsvLines { get; set; }
            public CsvReader CsvReader { get; set; }
        }

        public  MockedValues GetMockedValues()
        {
            List<string> data = new List<string>()
            {
                "header1,header2,header3",
                "data1,data2,data3"
            };           

            MockedValues values = new MockedValues();

            values.CsvLines = data;
            values.provider = new Mock<ICsvInputProvider>();           
            values.provider.Setup(x => x.Read()).Returns(() => values.CsvLines);  
            values.CsvReader = CsvReader.Create(values.provider.Object);

            return values;
        }        
        
        #endregion


        [Fact]
        public void Read_DefaultMethod_UsesComma_ToSplitString()
        {
            //Arrange
            var mock = GetMockedValues();
            var csvReader = CsvReader.Create(mock.provider.Object);

            var row = new CsvRow();         
            List<CsvRow> expected = new List<CsvRow>()
            {
            row.NewRow("header1,header2,header3", "header1,header2,header3"),
            row.NewRow("data1,data2,data3", "header1,header2,header3")
            };

            //Act
            
            csvReader.Read();
            var result = csvReader.GetRows();

            //Assert            
            result[0].GetCol("header1").GetValue().Should().Be("header1");
            result[0].GetCol("header2").GetHeader().Should().Be("header2");

            result[1].GetCol("header1").GetValue().Should().Be("data1");
            result[1].GetCol("header2").GetValue().Should().Be("data2");
            result[1].GetCol("header3").GetValue().Should().Be("data3");           
        }
    }
}


