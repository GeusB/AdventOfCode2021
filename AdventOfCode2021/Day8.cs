using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public static class Day8
    {
        public static void Execute()
        {
            var fileLocation = "./Files/Day8.txt";

            Console.WriteLine(Part1(fileLocation));
            Console.WriteLine(Part2(fileLocation));
        }

        public static int Part2(string fileLocation)
        {
            return 0;
        }

        public static int Part1(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            return inputList.Sum(signalRecord => signalRecord.Digits.Count(x => x.Length is 2 or 3 or 4 or 7));
        }

        private static SignalRecord MapRecord(string line)
        {
            return new SignalRecord(line);
        }
    }

    public class SignalRecord
    {
        public SignalRecord(string line)
        {
            var split = line.Split('|');
            Patterns = split.First().Trim().Split(' ');
            Digits = split.Last().Trim().Split(' ');
        }

        public string[] Patterns { get; }
        public string[] Digits { get; }
    }
}