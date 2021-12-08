using AdventOfCode2021;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021Tests
{
    public class Day7Tests
    {
        [Fact]
        public void Part1_Example()
        {
            var location = "./Files/Day7_ex.txt";

            Day7.Part1(location).Should().Be(37);
        }

        [Fact]
        public void Part1()
        {
            var location = "./Files/Day7.txt";

            Day7.Part1(location).Should().Be(352331);
        }

        [Fact]
        public void Part2_Example()
        {
            var location = "./Files/Day7_ex.txt";

            Day7.Part2(location).Should().Be(2698445);
        }

        [Fact]
        public void Part2()
        {
            var location = "./Files/Day7.txt";

            Day7.Part2(location).Should().Be(1595779);
        }
    }
}