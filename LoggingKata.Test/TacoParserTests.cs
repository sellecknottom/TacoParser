using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", -84.677017)]
        [InlineData("34.071477,-84.296345,Taco Bell Alpharett...", -84.296345)]
        [InlineData("32.364153,-86.269979,Taco Bell Montgomery...", -86.269979)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line).Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638)]
        [InlineData("34.071477,-84.296345,Taco Bell Alpharett...", 34.071477)]
        [InlineData("32.364153,-86.269979,Taco Bell Montgomery...", 32.364153)]

        //TODO: Create a test called ShouldParseLatitude
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line).Location.Latitude;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", "Taco Bell Acwort...")]
        [InlineData("34.071477,-84.296345,Taco Bell Alpharett...", "Taco Bell Alpharett...")]
        [InlineData("32.364153,-86.269979,Taco Bell Montgomery...", "Taco Bell Montgomery...")]
        public void LocationName(string line, string expected)
        {   
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line).Name;
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
