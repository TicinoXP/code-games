using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace MaxWithoutComparators
{
    public class StackTest
    {
        [Theory]
//        [InlineData(0, 0, 0)]
//        [InlineData(1, 0, 1)]
//        [InlineData(0, 1, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(1, 10, 10)]
        [InlineData(50, 10, 50)]
        [InlineData(100000, 10, 100000)]

//        [InlineData(-1, 0, 0)]
//        [InlineData(-1, -1, -1)]
//        [InlineData(-1, -10, -1)]
//        [InlineData(-10, -1, -1)]
        public void should_get_the_greater_number(int a, int b, int max)
        {
            var actual = new StackMax().Max(a, b);

            actual.Should().Be(max);
        }
    }

    public class StackMax
    {
        public int Max(int a, int b)
        {
            return Enumerable.Repeat(a, a).Concat(Enumerable.Repeat(b, b).Skip(b).ToList()[0];
        }
    }
}
