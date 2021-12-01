using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2021
{
    public static class Day1
    {
        public static void Execute()
        {
            GetDepthCount("./Files/Day1_1_ex.csv");
            GetDepthCount("./Files/Day1_1.csv");
        }

        private static void GetDepthCount(string location)
        {
            var inputList = Tools.ReadListFromFile(ConvertToInt, location);
            var count = 0;
            for (int i = 1; i < inputList.Count; i++)
            {
                count += inputList[i] > inputList[i - 1] ? 1 : 0;
                ;
            }

            Console.WriteLine(count);
        }

        private static int ConvertToInt(string? line)
        {
            return int.Parse(line ?? string.Empty);
        }
    }
}