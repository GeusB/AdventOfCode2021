using AdventOfCode2021;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021Tests
{
    public class Day10Tests
    {
        [Fact]
        public void Part1_Example()
        {
            var location = "./Files/Day10_ex.txt";

            Day10.Part1(location).Should().Be(26);
        }

        [Fact]
        public void Part1()
        {
            var location = "./Files/Day10.txt";

            Day10.Part1(location).Should().Be(352331);
        }

        [Fact]
        public void Part2_Example()
        {
            var location = "./Files/Day10_ex.txt";

            Day10.Part2(location).Should().Be(168);
        }

        [Fact]
        public void Part2()
        {
            var location = "./Files/Day10.txt";

            Day10.Part2(location).Should().Be(99266250);
        }
    }
}