using System;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day2
    {
        public static void Execute()
        {
            Part1("./Files/Day2_ex.csv");
            Part1("./Files/Day2.csv");

            Part2("./Files/Day2_ex.csv");
            Part2("./Files/Day2.csv");
        }

        private static void Part2(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            var aim = 0;
            var position = 0;
            var depth = 0;
            foreach (var record in inputList)
            {
                position += record.Position;
                depth += record.Position * aim;
                aim += record.Delta;
            }

            var result = position * depth;
            Console.WriteLine(result);
        }

        private static void Part1(string fileLocation)
        {
            var inputList = Tools.ReadListFromFile(MapRecord, fileLocation);
            var position = inputList.Sum(x => x.Position);
            var depth = inputList.Sum(x => x.Delta);
            var result = position * depth;
            Console.WriteLine(result);
        }

        private static MovementRecord MapRecord(string? line)
        {
            var split = line.Split(" ").ToList();
            var record = new MovementRecord(split.First(), int.Parse(split.Last()));
            return record;
        }
    }

    public class MovementRecord
    {
        public MovementRecord(string direction, int distance)
        {
            switch (direction)
            {
                case "forward":
                    Position = distance;
                    break;
                case "up":
                    Delta = -distance;
                    break;
                case "down":
                    Delta = distance;
                    break;
                default:
                    Position = 0;
                    Delta = 0;
                    break;
            }
        }

        public int Position { get; }
        public int Delta { get; }
    }
}