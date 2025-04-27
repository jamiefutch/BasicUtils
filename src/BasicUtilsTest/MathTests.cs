using Xunit;
using BasicUtils;

namespace BasicUtilsTest
{
    public class MathTests
    {
        [Fact]
        public void FastModForLoop_ShouldReturnTrue_WhenLimitCountExceedsLimitMinusOne()
        {
            // Arrange
            long limitCount = 10;
            long limit = 10;

            // Act
            var result = BasicUtils.Math.FastModForLoop(limitCount, limit);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void FastModForLoop_ShouldReturnFalse_WhenLimitCountIsLessThanLimitMinusOne()
        {
            // Arrange
            long limitCount = 8;
            long limit = 10;

            // Act
            var result = BasicUtils.Math.FastModForLoop(limitCount, limit);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public void FastModForLoop_ShouldHandleLargeNumbers()
        {
            // Arrange
            long limitCount = 1_000_000_000;
            long limit = 1_000_000;

            // Act
            var result = BasicUtils.Math.FastModForLoop(limitCount, limit);

            // Assert
            Assert.True(result);
        }
    }
}
