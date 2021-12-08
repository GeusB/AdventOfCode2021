using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day6
    {
        public static void Execute()
        {
            var fileLocation = "./Files/Day6.txt";

            Console.WriteLine(Part1(fileLocation, 79));
            Console.WriteLine(Part2(fileLocation, 255));
        }

        public static long Part2(string fileLocation, int days)
        {
            var numbers = Tools.GetNumbers(fileLocation);
            var fishLevelDict = numbers.GroupBy(x => x).ToDictionary(x => x.Key, x => (long) x.Count());
            AddMissingKeys(fishLevelDict);

            for (var i = 0; i < days; i++)
            {
                var fishReproducing = fishLevelDict[0];
                for (var j = 0; j < 8; j++)
                {
                    fishLevelDict[j] = fishLevelDict[j + 1];
                }
                fishLevelDict[6] += fishReproducing;
                fishLevelDict[8] = fishReproducing;
            }
            return fishLevelDict.Sum(x => x.Value);
        }

        private static void AddMissingKeys(Dictionary<int, long>? fishLevelDict)
        {
            for (var f = 0; f <= 8; f++)
                if (!fishLevelDict.ContainsKey(f))
                    fishLevelDict.Add(f, 0);
        }

        public static long Part1(string fileLocation, int roundsLeft)
        {
            var numbers = Tools.GetNumbers(fileLocation);
            var result = Recalculate(numbers, roundsLeft);
            return result.Count;
        }

        private static List<int> Recalculate(List<int> numbers, int roundsLeft)
        {
            if (roundsLeft == 0)
                return numbers;

            var toAdd = new List<int>();
            var newList = new List<int>();
            foreach (var number in numbers)
            {
                if (number == 0)
                {
                    newList.Add(6);
                    toAdd.Add(8);
                }
                else
                    newList.Add(number - 1);
            }

            if (toAdd.Any())
                newList.AddRange(toAdd);

            return Recalculate(newList, --roundsLeft);
        }
    }
}