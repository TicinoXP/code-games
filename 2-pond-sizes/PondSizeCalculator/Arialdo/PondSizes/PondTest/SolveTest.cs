using FluentAssertions;
using Xunit;

namespace PondSizes.PondTest
{
    public class SolveTest
    {
        [Fact]
        public void should_not_contain_a_never_added_spot()
        {
            var sut = Pond.Build(100, 200);

            var actual = sut.Contains(1, 2);

            actual.Should().Be(false);
        }

        [Fact]
        public void should_contain_added_spots()
        {
            var sut = Pond.Build(1, 2);

            var actual = sut.Contains(1, 2);

            actual.Should().Be(true);
        }
    }
}