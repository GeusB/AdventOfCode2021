using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day7
    {
        public static void Execute()
        {
            var fileLocation = "./Files/Day7.txt";

            Console.WriteLine(Part1(fileLocation));
            Console.WriteLine(Part2(fileLocation));
        }

        public static int Part1(string fileLocation)
        {
            var numbers = Tools.GetNumbers(fileLocation);
            var distanceDict = numbers.GroupBy(x => x).ToDictionary(x => x.Key, x => (long) x.Count());
            return GetMinimum(Math.Abs, distanceDict);
        }

        public static int Part2(string fileLocation)
        {
            var numbers = Tools.GetNumbers(fileLocation);
            var distanceDict = numbers.GroupBy(x => x).ToDictionary(x => x.Key, x => (long) x.Count());
            return GetMinimum(GetCostForDistance, distanceDict);
        }

        private static int GetMinimum(Func<int, int> func,  Dictionary<int, long> distanceDict)
        {
            var min = distanceDict.Keys.Min();
            var max = distanceDict.Keys.Max();
            var minimum = int.MaxValue;
            for (var i = min; i <= max; i++)
            {
                var cost = distanceDict.Sum(distance => func(Math.Abs(i - distance.Key)) * distance.Value);
                minimum = (int) Math.Min(minimum, cost);
            }
            return minimum;
        }

        private static int GetCostForDistance(int distance)
        {
            var cost = 0;
            for (var i = 1; i <= distance; i++)
            {
                cost += i;
            }
            return cost;
        }
    }
}