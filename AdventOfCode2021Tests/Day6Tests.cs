using AdventOfCode2021;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021Tests
{
    public class Day6Tests
    {
        [Fact]
        public void Part1_Example()
        {
            var location = "./Files/Day6_ex.txt";

            Day6.Part1(location, 79).Should().Be(5934);
        }

        [Fact]
        public void Part1()
        {
            var location = "./Files/Day6.txt";

            Day6.Part1(location, 79).Should().Be(351188);
        }

        [Fact]
        public void Part2_Example()
        {
            var location = "./Files/Day6_ex.txt";

            Day6.Part2(location, 255).Should().Be(26984457539);
        }

        [Fact]
        public void Part2()
        {
            var location = "./Files/Day6.txt";

            Day6.Part2(location, 255).Should().Be(20484);
        }
    }
}