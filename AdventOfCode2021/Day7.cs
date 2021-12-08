using System;
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

        public static int Part2(string fileLocation)
        {
            var numbers = Tools.GetNumbers(fileLocation);
           
            
            return 0;
        }

        public static int Part1(string fileLocation)
        {
            var numbers = Tools.GetNumbers(fileLocation);
            var distanceDict = numbers.GroupBy(x => x).ToDictionary(x => x.Key, x => (long) x.Count());
            var min = distanceDict.Keys.Min();
            var max = distanceDict.Keys.Max();
            var minimum = int.MaxValue;
            for (var i = min; i <= max; i++)
            {
                long cost = 0;
                foreach (var distance in distanceDict)
                {
                    cost += Math.Abs(i - distance.Key) * distance.Value;
                }

                minimum = (int) Math.Min(minimum, cost);
            }
            return minimum;
        }
    }
}