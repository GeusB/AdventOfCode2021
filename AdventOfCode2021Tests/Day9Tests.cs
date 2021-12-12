using AdventOfCode2021;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021Tests
{
    public class Day9Tests
    {
        [Fact]
        public void Part1_Example()
        {
            var location = "./Files/Day9_ex.txt";

            Day9.Part1(location).Should().Be(15);
        }

        [Fact]
        public void Part1()
        {
            var location = "./Files/Day9.txt";

            Day9.Part1(location).Should().Be(633);
        }

        [Fact]
        public void Part2_Example()
        {
            var location = "./Files/Day9_ex.txt";

            Day9.Part2(location).Should().Be(168);
        }

        [Fact]
        public void Part2()
        {
            var location = "./Files/Day9.txt";

            Day9.Part2(location).Should().Be(99266250);
        }
    }
}