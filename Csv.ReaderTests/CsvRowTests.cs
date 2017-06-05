using Csv.Types.Read;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Csv.ReaderTests
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
            var result2= row.GetCol("header3").GetValue();

            //Assert
            resutl1.Should().Be(expectedHeader);
            result2.Should().Be(expectedValue);
        }

        [Fact]
        public void NewRow_FewerHeadersThanValues_ThrowsArgumentException()
        {
            //Arrange
            valueLine = "data1,data2,data3,data4";
            headerLine = "header1,header2";
            //Act
            Action act = () => row.NewRow(valueLine, headerLine);

            //Assert
            act.ShouldThrow<ArgumentException>();                         
        }

        #endregion

        #region " Separator Char"

        [Fact]
        public void NewRow_SeparatorProvided_StringSplitCorrectly()
        {
            //Arrange
            valueLine = "data1;data2;data2";
            headerLine = "header1;header2;header3";           
            var expectedValue = "data1";

            //Act
            row.NewRow(valueLine, headerLine,';');
            var resultValue = row.GetCol("header1").GetValue();

            //Assert          
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void NewRow_IncorrectSeparator_StringNotSplit()
        {
            //Arrange
            valueLine = "data1,data2,data2";
            headerLine = "header1,header2,header3";

            var expectedHeader = "";
            var expectedValue = "";

            //Act
            row.NewRow(valueLine, headerLine,';');
            var resutlHeader = row.GetCol("header1").GetHeader();
            var resultValue = row.GetCol("header1").GetValue();

            //Assert
            resutlHeader.Should().Be(expectedHeader);
            resultValue.Should().Be(expectedValue);

        }

        #endregion

        #region " Quote Char"

        [Fact]
        public void NewRow_CorrectQuoteCharProvided_QuotesRemoved_FromRowValues()
        {
            //Arrange
            valueLine = "'data1','data2','data2'";
            headerLine = "'header1','header2','header3'";
            var expectedHeader = "header1";
            var expectedValue = "data1";

            //Act           
            row.NewRow(valueLine, headerLine,',','\'');
            var resutlHeader = row.GetCol("header1").GetHeader();
            var resultValue = row.GetCol("header1").GetValue();

            //Assert
            resutlHeader.Should().Be(expectedHeader);
            resultValue.Should().Be(expectedValue);
        }

        [Fact]
        public void NewRow_InCorrectQuoteCharProvided_QuoutesNotRemoved_FromRowValues()
        {
            //Arrange
            valueLine = "*data1*,*data2*,*data2*";
            headerLine = "*header1*,*header2*,*header3*";
            var expectedHeader = "*header1*";
            var expectedValue = "*data1*";

            //Act           
            row.NewRow(valueLine, headerLine, ',', ';');
            var resutlHeader = row.GetCol("*header1*").GetHeader();
            var resultValue = row.GetCol("*header1*").GetValue();

            //Assert
            resutlHeader.Should().Be(expectedHeader);
            resultValue.Should().Be(expectedValue);
        }

        #endregion
        
    }
}
