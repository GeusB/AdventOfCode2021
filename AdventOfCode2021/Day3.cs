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
            var bits = GetWinningBits(inputList);

            var oxygenRatingBits = FilterByMost(inputList, bits, 0);
            var oxygenRating = Convert.ToInt32(oxygenRatingBits, 2);

            var scrubberRatingBits = FilterByLeast(inputList, bits, 0);
            var scrubberRating = Convert.ToInt32(scrubberRatingBits, 2);
            
            Console.WriteLine(oxygenRating * scrubberRating);
        }

        private static string FilterByMost(List<string> inputList, string bits, int position)
        {
            var workingList = inputList.Where(x => x[position] == bits[position]).ToList();
            return workingList.Count == 1
                ? workingList.Single()
                : FilterByMost(workingList, GetWinningBits(workingList, 1), position + 1);
        }
        
        private static string FilterByLeast(List<string> inputList, string bits, int position)
        {
            if (inputList.Count == 2 && inputList.First()[position] != inputList.Last()[position])
                return inputList.Single(x => x[position] == '0');
            var workingList = inputList.Where(x => x[position] != bits[position]).ToList();
            return workingList.Count == 1
                ? workingList.Single()
                : FilterByLeast(workingList, GetWinningBits(workingList, 0), position + 1);
        }

        private static void Part1(string location)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, location);
            var lineLength = inputList.First().Length;
            var maxIntValue = Math.Pow(2, lineLength) - 1;
            var gammaBits = GetWinningBits(inputList);

            var gamma = Convert.ToInt32(gammaBits, 2);
            var epsilon = maxIntValue - gamma;
            Console.WriteLine(gamma * epsilon);
        }

        private static string? GetWinningBits(List<string>? inputList, int? draw = null)
        {
            var listCount = inputList.Count;
            var halfCount = listCount / 2;
            var lineLength = inputList.First().Length;
            var gammaBits = "";

            for (var i = 0; i < lineLength; i++)
            {
                if (draw != null)
                {
                    var matchCount = inputList.Count(x => x[i] == '1');
                    if (matchCount == listCount - matchCount)
                    {
                        if (draw == 1)
                        {
                            gammaBits += "1";
                        }
                        else
                        {
                            gammaBits += "0";
                        }
                    }
                    else
                    {
                        gammaBits += inputList.Count(x => x[i] == '1') > halfCount ? "1" : "0";
                    }
                }
                else
                {
                    gammaBits += inputList.Count(x => x[i] == '1') > halfCount ? "1" : "0";
                }
            }

            return gammaBits;
        }

        private static string? MapRecord(string? line)
        {
            return line;
        }
    }
}