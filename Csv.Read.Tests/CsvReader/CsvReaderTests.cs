using Csv.IO.CsvRead;
using Csv.Read.CsvReader;
using Csv.Types.Read;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.Read.Tests.CsvReader
{
    public class CsvReaderTests
    {
        #region " SET UP"
        List<string> data = new List<string>()
            {  "Header1,Header2,Header3",
                "Item11,Item12,Item13",
                "Item21,Item22,Item23"
            };
        Mock<ICsvInputProvider> mockProvider = new Mock<ICsvInputProvider>();
        CsvRow first = new CsvRow().NewRow("Item11,Item12,Item13", "Header1,Header2,Header3");
        CsvRow second = new CsvRow().NewRow("Item21,Item22,Item23", "Header1,Header2,Header3");
        CsvRow third = new CsvRow().NewRow("Item31,Item32,Item33", "Header1,Header2,Header3");
        

        #endregion

        //[Fact]
        public void CsvReadMethod_CsvLinesProvided_Returns3CsvRows()
        {
            //Arrange        
            //mockProvider.Setup(x => x.Read()).Returns(data);
            var csvReader = Csv.Read.CsvReader.CsvReader.Create(mockProvider.Object);
            List<CsvRow> expected = new List<CsvRow>();
            expected.Add(first); expected.Add(second); expected.Add(third);

            //Act
            csvReader.Read();
            List<CsvRow> result = csvReader.GetRows();

            //Assert            
            result.ShouldBeEquivalentTo(expected);
        }
    }
}
