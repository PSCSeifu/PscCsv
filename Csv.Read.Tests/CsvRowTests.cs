using Csv.Types.Read;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.Read.Tests
{
    public class CsvRowTests
    {
        #region " SET UP " 
        CsvRow row = new CsvRow();
        string valueLine = "";
        string headerLine = "";

        #endregion

        #region " Default  "

        [Fact]
        public void NewRow_DefaultCondition_ColsCreated_CommaSeprator_NoQuotesRemoved()
        {
            //Arrange
            valueLine = "data1,data2,data2";
            headerLine = "header1,header2,header3";

            var expectedHeader = "header1";
            var expectedValue = "data1";

            //Act
            row.NewRow(valueLine, headerLine);
            var resutlHeader = row.GetCol("header1").GetHeader();
            var resultValue = row.GetCol("header1").GetValue();

            //Assert
            resutlHeader.Should().Be(expectedHeader);
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void NewRow_EmptyParameters_ReturnsEmpty_StringValues()
        {
            //Arrange
            headerLine = "";
            valueLine = "";
            var expectedHeader = "";
            var expectedValue = "";

            //Act
            row.NewRow(valueLine, headerLine);
            var resutlHeader = row.GetCol("").GetHeader();
            var resultValue = row.GetCol("").GetValue();

            //Assert
            resutlHeader.Should().Be(expectedHeader);
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void NewRow_FewerValuesThanHeaders_OrphanedHeaders_HaveEmptyValues()
        {
            //Arrange
            valueLine = "data1,data2";
            headerLine = "header1,header2,header3,Header4";
            var expectedHeader = "header3";
            var expectedValue = "";
            
            //Act
            row.NewRow(valueLine, headerLine);
            var resutl1 = row.GetCol("header3").GetHeader();
            var result2= row.GetCol("header4").GetValue();

            //Assert
            resutl1.Should().Be(expectedHeader);
            result2.Should().Be(expectedValue);
        }

        [Fact]
        public void NewRow_FewerHeadersThanValues_ExpectedResult()
        {
            //Arrange
            valueLine = "data1,data2,data3,data4";
            headerLine = "header1,header2";
            var expectedValue = "data3";

            //Act
            row.NewRow(valueLine, headerLine);
            var resutl1 = row.GetCol("").GetHeader();
            var result2 = row.GetCol("").GetValue();

            //Assert
            resutl1.Should().Be("");
            result2.Should().Be(expectedValue);
        }

        #endregion

        #region " Separator Char"

        #endregion

        #region " Quote Char"

        #endregion

        #region " End of Line String"

        #endregion
    }
}
