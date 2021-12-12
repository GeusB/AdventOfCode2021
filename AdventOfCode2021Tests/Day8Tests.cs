using AdventOfCode2021;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021Tests
{
    public class Day8Tests
    {
        [Fact]
        public void Part1_Example()
        {
            var location = "./Files/Day8_ex.txt";

            Day8.Part1(location).Should().Be(26);
        }

        [Fact]
        public void Part1()
        {
            var location = "./Files/Day8.txt";

            Day8.Part1(location).Should().Be(554);
        }

        [Fact]
        public void Part2_Example()
        {
            var location = "./Files/Day8_ex.txt";

            Day8.Part2(location).Should().Be(61229);
        }

        [Fact]
        public void Part2()
        {
            var location = "./Files/Day8.txt";

            Day8.Part2(location).Should().Be(990964);
        }
    }
}