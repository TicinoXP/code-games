using FluentAssertions;
using Xunit;

namespace PondSizes.LandTest
{
    public class BuildTest
    {
        [Fact]
        public void should_create_world()
        {
            var inp = @"1  2  3  4  5
                        6  7  8  9  10
                        11 12 13 14 15";

            var land = Builder.Build(inp);

            land.Spots[0, 0].Should().Be(1);
            land.Spots[0, 1].Should().Be(2);
            land.Spots[0, 2].Should().Be(3);
            land.Spots[0, 3].Should().Be(4);
            land.Spots[0, 4].Should().Be(5);

            land.Spots[1, 0].Should().Be(6);
            land.Spots[1, 1].Should().Be(7);
            land.Spots[1, 2].Should().Be(8);
            land.Spots[1, 3].Should().Be(9);
            land.Spots[1, 4].Should().Be(10);

            land.Spots[2, 0].Should().Be(11);
            land.Spots[2, 1].Should().Be(12);
            land.Spots[2, 2].Should().Be(13);
            land.Spots[2, 3].Should().Be(14);
            land.Spots[2, 4].Should().Be(15);
        }

        [Fact]
        public void should_split_line()
        {
            var numbers = Builder.SplitLine("  1   2     3   4  5");

            numbers[0].Should().Be(1);
            numbers[1].Should().Be(2);
            numbers[2].Should().Be(3);
            numbers[3].Should().Be(4);
            numbers[4].Should().Be(5);
        }

        [Fact]
        public void should_split_lines()
        {
            var inp = @"1  2  3  4  5
                        6  7  8  9  10
                        11 12 13 14 15";

            inp = Builder.Clean(inp);
            var lines = Builder.SplitLines(inp);

            lines[0].Should().Be("1 2 3 4 5");
            lines[1].Should().Be("6 7 8 9 10");
            lines[2].Should().Be("11 12 13 14 15");
        }
    }
}