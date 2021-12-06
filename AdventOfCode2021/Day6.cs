using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        public static long Part2(string fileLocation, int roundsLeft)
        {
            return Part1(fileLocation, roundsLeft);
        }

        public static long Part1(string fileLocation, int roundsLeft)
        {
            using var reader = new StreamReader(fileLocation, Encoding.Default);
            var firstLine = reader.ReadLine();
            var numbers = firstLine.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(y => (int?) int.Parse(y))
                .ToList();
            var result = Recalculate(numbers, roundsLeft);


            return result.Count;
        }

        private static List<int?> Recalculate(List<int?> numbers, int roundsLeft)
        {
            var toAdd = new List<int?>();
            var newList = new List<int?>();
            foreach (var number in numbers)
            {
                if (number == 0)
                {
                    newList.Add(6);
                    toAdd.Add(8);
                }
                else
                {
                    newList.Add(number - 1);
                }
            }

            if (toAdd.Any())
                newList.AddRange(toAdd);

            if (roundsLeft == 0)
            {
                return newList;
            }
            else
            {
                return Recalculate(newList, --roundsLeft);
            }
        }
    }
}