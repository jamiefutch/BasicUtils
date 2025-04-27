using Xunit;
using BasicUtils;
using System.IO;
using System.Threading.Tasks;

namespace BasicUtilsTest
{
    public class CsvTests
    {
        private const string TestCsvPath = "test.csv";

        [Fact]
        public void LoadRawCsv_ShouldReturnAllLines_WhenNoHeader()
        {
            // Arrange
            File.WriteAllText(TestCsvPath, "Header1,Header2\nValue1,Value2\nValue3,Value4");

            // Act
            var result = Csv.LoadRawCsv(TestCsvPath, hasHeader: false);

            // Assert
            Assert.Equal(3, result.Length);
            Assert.Equal("Header1,Header2", result[0]);
            Assert.Equal("Value1,Value2", result[1]);
            Assert.Equal("Value3,Value4", result[2]);

            // Cleanup
            File.Delete(TestCsvPath);
        }

        [Fact]
        public void LoadRawCsv_ShouldSkipHeader_WhenHasHeaderIsTrue()
        {
            // Arrange
            File.WriteAllText(TestCsvPath, "Header1,Header2\nValue1,Value2\nValue3,Value4");

            // Act
            var result = Csv.LoadRawCsv(TestCsvPath, hasHeader: true);

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Equal("Value1,Value2", result[0]);
            Assert.Equal("Value3,Value4", result[1]);

            // Cleanup
            File.Delete(TestCsvPath);
        }

        [Fact]
        public async Task LoadRawCsvAsync_ShouldReturnAllLines_WhenNoHeader()
        {
            // Arrange
            File.WriteAllText(TestCsvPath, "Header1,Header2\nValue1,Value2\nValue3,Value4");

            // Act
            var result = await Csv.LoadRawCsvAsync(TestCsvPath, hasHeader: false);

            // Assert
            Assert.Equal(3, result.Length);
            Assert.Equal("Header1,Header2", result[0]);
            Assert.Equal("Value1,Value2", result[1]);
            Assert.Equal("Value3,Value4", result[2]);

            // Cleanup
            File.Delete(TestCsvPath);
        }

        [Fact]
        public async Task LoadRawCsvAsync_ShouldSkipHeader_WhenHasHeaderIsTrue()
        {
            // Arrange
            File.WriteAllText(TestCsvPath, "Header1,Header2\nValue1,Value2\nValue3,Value4");

            // Act
            var result = await Csv.LoadRawCsvAsync(TestCsvPath, hasHeader: true);

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Equal("Value1,Value2", result[0]);
            Assert.Equal("Value3,Value4", result[1]);

            // Cleanup
            File.Delete(TestCsvPath);
        }
    }
}
