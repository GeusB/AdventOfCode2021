using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day2
    {
        public static void Execute()
        {
            Part1("./Files/Day2_ex.csv");
            Part1("./Files/Day2.csv");
        }

        private static void Part2(string fileLocation)
        {
            //var inputList = Tools.ReadListFromFile(ConvertToInt, fileLocation);
        }


        private static void Part1(string location)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, location);
            var position = inputList.Sum(x => x.Position);
            var depth = inputList.Sum(x => x.DepthDelta);
            var result = position * depth;
            Console.WriteLine(result);
        }


        private static Record MapRecord(string? line)
        {
            var split = line.Split(" ").ToList();
            var record = new Record(split.First(), int.Parse(split.Last()));
            return record;
        }
    }

    public class Record
    {
        public Record(string direction, int distance)
        {
            switch (direction)
            {
                case "forward":
                    Position = distance;
                    break;
                case "up":
                    DepthDelta = -distance;
                    break;
                case "down":
                    DepthDelta = distance;
                    break;
                default:
                    Position = 0;
                    DepthDelta = 0;
                    break;
            }
        }

        public int Position { get; }
        public int DepthDelta { get; }
    }
}