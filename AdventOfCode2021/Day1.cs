using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public static class Day1
    {
        public static void Execute()
        {
            var day = nameof(Day1);
            var exampleLocation = $"./Files/{day}_ex.txt";
            var fileLocation = $"./Files/{day}.txt";
            
            Part1(exampleLocation);
            Part1(fileLocation);

            Part2(exampleLocation);
            Part2(fileLocation);
        }

        private static void Part2(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(ConvertToInt, fileLocation);
            var windowList = new List<int>();
            var listLength = inputList.Count;
            for (var i = 0; i < listLength - 2; i++)
            {
                var sumDepth = inputList[i];
                for (var j = 1; j < 3; j++)
                    if (i + j < listLength)
                        sumDepth += inputList[i + j];
                windowList.Add(sumDepth);
            }

            Console.WriteLine(GetIncreases(windowList));
        }


        private static void Part1(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(ConvertToInt, fileLocation);
            var count = GetIncreases(inputList);
            Console.WriteLine(count);
        }

        private static int GetIncreases(List<int>? inputList)
        {
            var count = 0;
            for (var i = 1; i < inputList.Count; i++)
                count += inputList[i] > inputList[i - 1] ? 1 : 0;
            return count;
        }

        private static int ConvertToInt(string? line)
        {
            return int.Parse(line ?? string.Empty);
        }
    }
}