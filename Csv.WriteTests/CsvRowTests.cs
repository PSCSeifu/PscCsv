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
    public class CsvRowTests
    {
        #region " SET UP " 
        CsvRow row = new CsvRow();           
        public void SetCols()
        {
            row.AddCol("data1");
            row.AddCol("data2");
            row.AddCol("data3");
        }
        #endregion
        
        
        [Fact]
        public void ToLine_DefaultCall_ReturnsString_ValuesSeparatedByComma()
        {
            //Arrange
            SetCols();
            string expected = "data1,data2,data3";

            //Act
            var result = row.ToLine();

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ToLine_SepratorCharProvided_ReturnsString_ValuesSeparatedByProvidedChar()
        {
            //Arrange
            SetCols();
            string expectedColon = "data1:data2:data3";
            string expectedTilda = "data1~data2~data3";

            //Act
            string resultColon = row.ToLine(':');
            string resultTilda = row.ToLine('~');

            //Assert
            resultColon.Should().Be(expectedColon);
            resultTilda.Should().Be(expectedTilda);
        }

        [Fact]
        public void ToLine_SepratorSetAsCharMinvalue_DefaultsToComma()
        {
            //Arrange
            SetCols();
            string expected = "data1,data2,data3";

            //Act
            var result = row.ToLine(char.MinValue);

            //Assert
            result.Should().Be(expected);
        }

        
        [Fact]
        public void ToLine_QuoteCharProvided_ReturnsValues_WrappedByQuoteChar()
        {
            //Arrange          
            SetCols();
            string expectedSingleQuote = "'data1','data2','data3'";
            string expectedDoubleQuote = "\"data1\",\"data2\",\"data3\"";

            //Act
            var resultSingleQuote = row.ToLine(',', '\'');
            var resultDoubleQuote = row.ToLine(',', '"');

            //Assert
            resultSingleQuote.Should().Be(expectedSingleQuote);
            expectedDoubleQuote.Should().Be(expectedDoubleQuote);
        }

        [Fact]
        public void ToLine_QuoteSetAsCharMinvalue_DefaultsTo_ValuesNotQuoteWrapped()
        {
            //Arrange          
            SetCols();
            string expectedNoQuote = "data1,data2,data3";

            //Act
            var resultNoQuote = row.ToLine(',', char.MinValue);

            //Assert
            resultNoQuote.Should().Be(expectedNoQuote);
        }


        [Fact]
        public void ToLine_EndOfLineStringProvided_StringIsAppended_AtEndOfString()
        {
            //Arrange           
            SetCols();
            string expected = "data1,data2,data3#";
            string expected2 = "data1,data2,data3# %";

            //Act
            string result = row.ToLine(',',char.MinValue,"#");
            string result2 = row.ToLine(',', char.MinValue, "# %");

            //Assert
            result.Should().Be(expected);
            result2.Should().Be(expected2);

            result.Last().Should().Be('#');
            result2.Substring(result.Length - 1, 3).Should().Be("# %");
        }

        [Fact]
        public void ToLine_NullEndOfLineProvided_NoStringAppended_AtStringEnd()
        {
            //Arrange           
            SetCols();
            string expected = "data1,data2,data3";

            //Act
            string result = row.ToLine(',', char.MinValue, null);

            //Assert
            result.Should().Be(expected);
            result.Last().Should().Be('3');
        }

        [Fact]
        public void ToLine_EmptyEndOfLineProvided_NoStringAppended_AtStringEnd()
        {
            //Arrange           
            SetCols();
            string expected = "data1,data2,data3";

            //Act
            string result = row.ToLine(',', char.MinValue, "");

            //Assert
            result.Should().Be(expected);
            result.Last().Should().Be('3');
        }





    }
}
