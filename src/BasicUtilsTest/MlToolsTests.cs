using Xunit;
using BasicUtils;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicUtils.MLTools;

namespace BasicUtilsTest
{
    public class MlToolsTests
    {
        private readonly MlUtils _mlUtils = new();

        [Fact]
        public void GetNgramsFromString_ShouldReturnCorrectNgrams()
        {
            // Arrange
            string input = "This is a test";
            int ngramLength = 2;

            // Act
            var result = _mlUtils.GetNgramsFromString(input, ngramLength);

            // Assert
            var expected = new List<string> { "This|is", "is|a", "a|test" };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetNgramsFromString_ShouldHandleEmptyString()
        {
            // Arrange
            string input = "";
            int ngramLength = 2;

            // Act
            var result = _mlUtils.GetNgramsFromString(input, ngramLength);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetNgramsFromString_ShouldHandleShorterTextThanNgramLength()
        {
            // Arrange
            string input = "Short";
            int ngramLength = 2;

            // Act
            var result = _mlUtils.GetNgramsFromString(input, ngramLength);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetNgramsFromStringAsync_ShouldReturnCorrectNgrams()
        {
            // Arrange
            string input = "Async test case";
            int ngramLength = 2;

            // Act
            var result = await _mlUtils.GetNgramsFromStringAsync(input, ngramLength);

            // Assert
            var expected = new List<string> { "Async|test", "test|case" };
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetNgramsFromStringAsync_ShouldHandleEmptyString()
        {
            // Arrange
            string input = "";
            int ngramLength = 2;

            // Act
            var result = await _mlUtils.GetNgramsFromStringAsync(input, ngramLength);

            // Assert
            Assert.Empty(result);
        }
    }
}
