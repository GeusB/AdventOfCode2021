using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day3
    {
        public static void Execute()
        {
            Part1("./Files/Day3_ex.csv");
            Part1("./Files/Day3.csv");

            Part2("./Files/Day3_ex.csv");
            Part2("./Files/Day3.csv");
        }

        private static void Part2(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
        }

        private static void Part1(string location)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, location);
            var halfCount = inputList.Count / 2;
            var lineLength = inputList.First().Length;
            var maxIntValue = Math.Pow(2, lineLength) - 1;
            var gammaBits = GetGammaBits(lineLength, inputList, halfCount);

            var gamma = Convert.ToInt32(gammaBits, 2);
            var epsilon = maxIntValue - gamma;
            Console.WriteLine(gamma * epsilon);
        }

        private static string? GetGammaBits(int lineLength, List<string>? inputList, int halfCount)
        {
            var gammaBits = "";

            for (var i = 0; i < lineLength; i++) gammaBits += inputList.Count(x => x[i] == '1') > halfCount ? "1" : "0";

            return gammaBits;
        }

        private static string? MapRecord(string? line)
        {
            return line;
        }
    }
}