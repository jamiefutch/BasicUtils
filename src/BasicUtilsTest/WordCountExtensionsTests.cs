using System.Diagnostics;
using BasicUtils.StringsTools;

namespace BasicUtilsTest
{
    public class WordCountExtensionsTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("Hello", 1)]
        [InlineData("Hello world", 2)]
        [InlineData("  Hello   world  ", 2)]
        [InlineData("Hello, world!", 2)]
        [InlineData("One two three four five", 5)]
        [InlineData("   Leading and trailing   ", 3)]
        [InlineData("Multiple   spaces   between   words", 4)]
        [InlineData("Tabs\tand\nnewlines\r\nare whitespace", 5)]
        public void CountWords_ReturnsExpectedCount(string input, int expected)
        {
            Debug.Print(input);
            int actual = input.CountWords();
            Assert.Equal(expected, actual);
        }
    }
}
