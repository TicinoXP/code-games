using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MaxWithoutComparators
{
    public class ArialdoTest
    {
        private readonly Arialdo _sut = new Arialdo();

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
            var actual = _sut.Max(a, b);

            actual.Should().Be(max);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, true)]
        [InlineData(1, 1, false)]
        public void should_detect_when_a_is_bigger(int a, int b, bool expected)
        {
            var ab = Arialdo.ToBoolean(a);
            var bb = Arialdo.ToBoolean(b);
            var actual = _sut.IsBigger(ab, bb);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(1, 1, true)]
        public void should_detect_when_a_and_b_are_equal(int a, int b, bool expected)
        {
            var ab = Arialdo.ToBoolean(a);
            var bb = Arialdo.ToBoolean(b);
            var actual = _sut.AreEqual(ab, bb);

            actual.Should().Be(expected);
        }


        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 2)]
        [InlineData(1, 1, 3)]
        public void should_combine_2_bits(int a, int b, int combined)
        {
            var actual = Arialdo.Combine(a, b);

            actual.Should().Be(combined);
        }

        [Theory]
        [InlineData(false, false, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, true)]
        [InlineData(false, true, false)]
        public void should_reduce_one_bit(bool a, bool b, bool expected)
        {
            var ab = new List<bool> {a};
            var bb = new List<bool> {b};

            var actual = _sut.AIsBigger(ab, bb);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        public void should_convert_bit_to_boolean(int value, bool expected)
        {
            var actual = Arialdo.ToBoolean(value);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 0)]
        public void should_convert_boolean_to_bit(bool value, int expected)
        {
            var actual = _sut.ToBit(value);

            actual.Should().Be(expected);
        }


        [Fact]
        public void should_go_on_when_there_are_items_in_the_list()
        {
            var list = new List<bool> {true, false, false, true};

            var actual = Arialdo.ThereAreOtherItems(list);

            actual.Should().BeTrue();
        }

        [Fact]
        public void shold_stop_when_there_are_no_item_in_the_list()
        {
            var list = new List<bool> {};

            var actual = Arialdo.ThereAreOtherItems(list);

            actual.Should().BeFalse();
        }

        [Fact]
        public void should_convert_to_binary()
        {
            var n = 1343;

            var binary = Arialdo.ConvertToBinary(n);

            //"10100111111"
            var expected = new List<bool> { true, false, true, false, false, true, true, true, true, true, true };
            binary.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void should_reduce_a_sequence_of_bits()
        {
            var ab = new List<bool> {true, true, true, true};
            var bb = new List<bool> {true, false, true, false};

            var actual = _sut.AIsBigger(ab, bb);

            actual.Should().Be(true);
        }
    }
}