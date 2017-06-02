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
    public class CsvColTests
    {
        [Fact]
        public void GetHeader_DefaultConstructor_ReturnsEmptyString()
        {
            //Arrange
            CsvCol sut = new CsvCol();
            string expected = "";

            //Act
            string result = sut.GetHeader();

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void GetHeader_OverloadConstructor_ReturnsProvided_HeaderString()
        {
            //Arrange
            CsvCol sut = new CsvCol("HeaderString","DataValue");
            string expected = "HeaderString";

            //Act
            string result =  sut.GetHeader();

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void GetValue_OverloadConstructor_ReturnsProvided_ValueString()
        {
            //Arrange
            CsvCol sut = new CsvCol("HeaderString", "DataValue");
            string expected = "DataValue";

            //Act
            string result = sut.GetValue();

            //Assert
            result.Should().Be(expected);
        }
    }
}
