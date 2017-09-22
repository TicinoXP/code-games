using Xunit;

namespace MaxWithoutComparators
{
    public class EmanueleTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(1, 10, 10)]
        [InlineData(50, 10, 50)]
        [InlineData(100000, 10, 100000)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, -1, -1)]
        [InlineData(-1, -10, -1)]
        [InlineData(-10, -1, -1)]
        public void should_get_the_greater_number(int a, int b, int max)
        {
            new Emanuele().Max(a, b);
        }
    }
}