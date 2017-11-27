using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PondSizes.PondTest
{
    public class BuildTest
    {
        [Fact]
        public void should_build_a_pond_with_1_spot()
        {
            var actual = Pond.Build(12, 100);

            actual.Contains(12, 100).Should().BeTrue();
        }

        [Fact]
        public void should_build_ponds_with_n_spots()
        {
            var sut = new Pond(new List<Spot>()
            {
                new Spot(1, 2),
                new Spot(5, 10),
                new Spot(100, 200)
            });
        }

        [Fact]
        public void should_melt_with_another_pond()
        {
            var sut = new Pond(new List<Spot>
            {
                new Spot(1, 2),
                new Spot(4, 5)
            });
            var another = new Pond(new List<Spot>
            {
                new Spot(100, 200),
                new Spot(300, 400)
            });

            var actual = sut.MeltWith(another);

            actual.Should().NotBeSameAs(sut);

            actual.Contains(1, 2).Should().Be(true);
            actual.Contains(4, 5).Should().Be(true);
            actual.Contains(100, 200).Should().Be(true);
            actual.Contains(300, 400).Should().Be(true);
        }


    }
}