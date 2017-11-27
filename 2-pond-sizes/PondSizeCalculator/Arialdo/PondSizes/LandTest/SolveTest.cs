using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PondSizes.LandTest
{
    public class SolveTest
    {
        [Fact]
        public void should_solve_example()
        {
            var sut = Builder.Build(@"0 2 1 0
                                   0 1 0 1
                                   1 1 0 1
                                   0 1 0 1");

            var actual = sut.Solve();

            actual.Should().BeEquivalentTo(new List<int> {1, 2, 4});
        }

        [Fact]
        public void should_stringify_maps()
        {
            var map = @"0 2 1 0
                        0 1 0 1
                        1 1 0 1
                        0 1 0 1";

            var actual = Stringfy(map);

            actual.Should().Be(@"0 2 1 0
0 1 0 1
1 1 0 1
0 1 0 1");
            ;
        }

        private static string Stringfy(string map)
        {

            var rows = Builder.Clean(map).Split('\r');
            var trimmedRows = rows.ToList().Select(s => s.Trim());

            return string.Join("\r\n", trimmedRows);
        }
    }
}